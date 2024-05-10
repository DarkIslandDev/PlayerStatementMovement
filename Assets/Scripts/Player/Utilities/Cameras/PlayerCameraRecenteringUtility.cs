using Cinemachine;
using UnityEngine;

[System.Serializable]
public class PlayerCameraRecenteringUtility
{
    [field: SerializeField] public CinemachineVirtualCamera VirtualCamera { get; set; }
    [field: SerializeField] public float DefaultHorizontalWaitTime { get; private set; } = 0f;
    [field: SerializeField] public float DefaultHorizontalRecenteringTime { get; private set; } = 4f;

    private CinemachinePOV cinemachinePOV;

    public void Init(Transform lookAt)
    {
        cinemachinePOV = VirtualCamera.GetCinemachineComponent<CinemachinePOV>();

        VirtualCamera.m_Follow = lookAt;
        VirtualCamera.m_LookAt = lookAt;
    }

    public void EnableRecentering(float waitTime = -1f, float recenteringTime = -1f, float baseMovementSpeed = 1f, float movementSpeed = 1f)
    {
        cinemachinePOV.m_HorizontalRecentering.m_enabled = true;

        cinemachinePOV.m_HorizontalRecentering.CancelRecentering();

        if (waitTime == -1f)
        {
            waitTime = DefaultHorizontalWaitTime;
        }

        if (recenteringTime == -1f)
        {
            recenteringTime = DefaultHorizontalRecenteringTime;
        }

        recenteringTime = recenteringTime * baseMovementSpeed / movementSpeed;

        cinemachinePOV.m_HorizontalRecentering.m_WaitTime = waitTime;
        cinemachinePOV.m_HorizontalRecentering.m_RecenteringTime = recenteringTime;
    }

    public void DisableRecentering()
    {
        cinemachinePOV.m_HorizontalRecentering.m_enabled = false;
    }
}