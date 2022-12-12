using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    MainInputManager inputManager;
    PlayerLocomotions playerLocomotion;
    CameraManager cameraManager;
    MinionBehavior minion;

    private void Awake()
    {
        inputManager = GetComponent<MainInputManager>();
        playerLocomotion = GetComponent<PlayerLocomotions>();
        cameraManager = FindObjectOfType<CameraManager>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate()
    {
        cameraManager.FollowPlayer();
    }
}
