using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public CarController carController;
    
    public float cameraFollowSpeed = 10f;
    public float cameraSideOffsetMax = 3f; 

    private CinemachineTransposer transposer;

    void Start()
    {
        transposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    void FixedUpdate()
    {
        float turnRatio = carController.turnAngle / carController.maxTurnAngle;

        float sideOffset = turnRatio * cameraSideOffsetMax;
        
        Vector3 followOffset = transposer.m_FollowOffset;
        followOffset.x = Mathf.Lerp(followOffset.x, sideOffset, cameraFollowSpeed * Time.deltaTime);

        transposer.m_FollowOffset = followOffset;
    }
}
