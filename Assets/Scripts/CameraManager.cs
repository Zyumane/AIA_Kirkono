using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform targetTransform;
    private Vector3 cameraFollowVeocity = Vector3.zero;
    public PlayerManager playerManager;

    public float cameraFollowSpeed = 0.2f;

    private void Awake()
    {
        targetTransform = FindObjectOfType<PlayerManager>().transform;
    }

    public void FollowPlayer()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, 
                                                    targetTransform.position, 
                                                    ref cameraFollowVeocity, 
                                                    cameraFollowSpeed);

        transform.position = targetPosition;
    }
}
