using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInputManager : MonoBehaviour
{
    MainPlayerControlsActions playerActions;
    AnimatorManager AnimatorManager;

    public Vector2 MovementInput;
    private float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    private void Awake()
    {
        AnimatorManager = GetComponent<AnimatorManager>();
    }

    private void OnEnable()
    {
        if(playerActions == null) 
        {
            playerActions = new MainPlayerControlsActions();

            playerActions.PlayerMovement.Movement.performed += i => MovementInput = i.ReadValue<Vector2>();
            
        }
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = MovementInput.y;
        horizontalInput = MovementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        AnimatorManager.UpdateAnimatorValues(0, moveAmount);
    }

}
