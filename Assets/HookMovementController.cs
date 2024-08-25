using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovementController : MonoBehaviour
{
    [SerializeField] private Transform hookDefaultPosition;
    [SerializeField] private float FloatSpeed = 2f;
    private Rigidbody2D rb;
    private bool isCollisionWithWater; 
    private bool isHookAttachedToRod;
    private float XInput;
    private float additionalSpeed = 1f;
    private float maxAdditionalSpeed;

    private void Start() 
    {
        maxAdditionalSpeed = additionalSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetNewVelocityOfHook(Vector2 newVelocity)
    {
        rb.velocity = newVelocity;
    }

    public void ChangeGravityOfHook(float newGravity)
    {
        rb.gravityScale = newGravity;
    }

    public void OnCollisionWithWater()
    {
       
        ChangeGravityOfHook(0.1f);
        isCollisionWithWater = true;
        float currentXVelocity = rb.velocity.x;
        float currrentYVelocity = rb.velocity.y;
        SetNewVelocityOfHook(new Vector2(0.5f, currrentYVelocity / 4));
    }



    private void Update() 
    {

        if(isCollisionWithWater)
        {
            XInput = Input.GetAxis("Horizontal");
        }
    }

    private void FixedUpdate() 
    {
        if(isCollisionWithWater)
        {
            float XSpeed = XInput * FloatSpeed;
            additionalSpeed -= Time.deltaTime;
            if(additionalSpeed <= 0)
                additionalSpeed = 0;
            rb.velocity = new Vector2(XInput + additionalSpeed, -1);
        }
        if(isHookAttachedToRod)
        {
            transform.position = hookDefaultPosition.position;
        }


    }

    public void ResetHook()
    {
        additionalSpeed = maxAdditionalSpeed;
        isCollisionWithWater = false;
        rb.velocity = new Vector2(0, 0);
    }

    public void SetIfHookIsAttachedToRod(bool isAttached)
    {
        isHookAttachedToRod = isAttached;
    }
}
