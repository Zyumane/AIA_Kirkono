using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Animator animator;
    int horizontal;
    int vertical;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
    {
        float snapHorizontal;
        float snapVertical;

        #region Snap Movement
        switch (horizontalMovement)
        {
            case > 0 and < 0.55f:
                snapHorizontal = 0.5f;
                break;
            case > 0.55f:
                snapHorizontal = 1;
                break;
            case < 0 and > -0.55f:
                snapHorizontal = -0.5f;
                break;
            case < -0.55f:
                snapHorizontal = -1;
                break;
            default:
                snapHorizontal = 0;
                break;
        }

        switch (verticalMovement)
        {
            case > 0 and < 0.55f:
                snapVertical = 0.5f;
                break;
            case > 0.55f:
                snapVertical = 1;
                break;
            case < 0 and > -0.55f:
                snapVertical = -0.5f;
                break;
            case < -0.55f:
                snapVertical = -1;
                break;
            default:
                snapVertical = 0;
                break;
        }
        #endregion

        animator.SetFloat(horizontal, snapHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snapVertical, 0.1f, Time.deltaTime);
        



    }
}
