using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseHookController : MonoBehaviour
{
    private HookMovementController hookMovementController;
    private bool releasedOneTime = false;
    [SerializeField] private Animator playerAnimator;

    private void Start() 
    {
        hookMovementController = GetComponent<HookMovementController>();
    }

    private void Update() 
    {
        if(Input.GetKey(KeyCode.Space) && !releasedOneTime)
        {
            PlayThrowAnimation();
            releasedOneTime = true;
        }
    }
    
    private void PlayThrowAnimation()
    {
        playerAnimator.SetBool("canPlayerThrow", true);
    }

    public void ReleaseFloat()
    {
        hookMovementController.SetIfHookIsAttachedToRod(false);
        ChangeGravityOfFloat(1);
        SetNewVelocityOfFloat(new Vector2(5, 2));
    }

    private void ChangeGravityOfFloat(float newGravityScale)
    {
        hookMovementController.ChangeGravityOfHook(newGravityScale);
    }

    private void SetNewVelocityOfFloat(Vector2 newVelocity)
    {
        hookMovementController.SetNewVelocityOfHook(newVelocity);
    }

    public void ResetHook()
    {
        releasedOneTime = false;
    }


}
