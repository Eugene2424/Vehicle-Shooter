using UnityEngine;
using Cinemachine;
using Game.Application;
using Game.Application.Gameplay;

public class CameraView : MonoBehaviour, ICameraView
{
    [SerializeField] private CinemachineVirtualCamera sideViewCamera;
    [SerializeField] private CinemachineVirtualCamera followViewCamera;
    
    public void SwitchToFollowView()
    {
        sideViewCamera.Priority = 0; 
        followViewCamera.Priority = 10; 
    }

    public void SwitchToSideView()
    {
        sideViewCamera.Priority = 10; 
        followViewCamera.Priority = 0; 
    }
}
