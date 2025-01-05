using System;
using System.Collections;
using Game.Application;
using Game.Application.Abstractions;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Infrastructure.Services
{
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        private ZenjectSceneLoader _zenjectSceneLoader;
        private ILoadingScreen _loadingScreen;
        
        [Inject]
        public void Construct(ZenjectSceneLoader zenjectSceneLoader,ILoadingScreen loadingScreen)
        {
            _zenjectSceneLoader = zenjectSceneLoader;
            _loadingScreen = loadingScreen;
        }

        public void LoadSceneAsync(string sceneName, Action onComplete = null)
        {
            _loadingScreen.Show();
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = false;

            _loadingScreen.UpdateProgress(asyncOperation.progress);
            StartCoroutine(UpdateProgress(asyncOperation, onComplete));
        }

        public void LoadScene(string sceneName)
        {
            _zenjectSceneLoader.LoadScene(sceneName, LoadSceneMode.Single);
        }

        private IEnumerator UpdateProgress(AsyncOperation asyncOperation, Action onComplete)
        {
            while (!asyncOperation.isDone)
            {
                _loadingScreen.UpdateProgress(asyncOperation.progress);
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }
                yield return null;
            }

            _loadingScreen.Hide();
            onComplete?.Invoke();
        }
    }
}