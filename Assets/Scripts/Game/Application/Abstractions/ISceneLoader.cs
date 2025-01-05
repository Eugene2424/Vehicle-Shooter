using System;

namespace Game.Application.Abstractions
{
    public interface ISceneLoader
    {
        void LoadSceneAsync(string sceneName, Action onComplete = null);
        void LoadScene(string sceneName);
    }
}