using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController
{
    // Player Components
    private Animator                animator;
    private Rigidbody2D             rigidbody;
    private InputSystem             inputSystem;
    private PlayerOnGroundSensor    onGroundSensor;
    private PlayerComponentManager  componentManager;

    // Procedural Parameters
    private float                   deltaX          = 0f;
    private float                   deltaY          = 0f;
    private bool                    runRight        = true;

    public PlayerMovementController
    (
        Animator                    animator,
        Rigidbody2D                 rigidbody,
        InputSystem                 inputSystem,
        PlayerComponentManager      componentManager
    )
    {
        this.animator               = animator;
        this.rigidbody              = rigidbody;
        this.inputSystem            = inputSystem;
        this.componentManager       = componentManager;

        onGroundSensor = rigidbody.transform.Find
        (
            "Sensor"
        ).gameObject.AddComponent<PlayerOnGroundSensor>();
    }

    public void Update()
    {
        DetectMovement();
        DetectAnimation();
    }

    private void DetectMovement()
    {
        deltaY = rigidbody.velocity.y;
        
        if (onGroundSensor.OnTrigger && inputSystem.GetJumpDown())
        {
            animator.SetTrigger("Jump");
            deltaY = componentManager.JumpSpeed;
        }

        deltaX = Mathf.Lerp(deltaX, inputSystem.GetRun(), componentManager.RunSpeedLerp);
        rigidbody.velocity = new Vector3(deltaX * componentManager.RunSpeed, deltaY);

        if (inputSystem.GetJet_Mouse())
        {
            rigidbody.AddForce
            (
                new Vector2
                (
                    0,
                    rigidbody.transform.position.y
                    - Camera.main.ScreenToWorldPoint(Input.mousePosition).y
                )
                * componentManager.JetThrust * Time.deltaTime
            );
            animator.SetBool("Jetting", true);
        }
        else if (inputSystem.GetJet_Key())
        {
            rigidbody.AddForce
            (
                new Vector2
                (
                    0,
                    componentManager.JetForce * componentManager.JetThrust
                )
                * Time.deltaTime
            );
            animator.SetBool("Jetting", true);
        }
    }

    private void DetectAnimation()
    {
        animator.SetBool("OnGround", onGroundSensor.OnTrigger);

        if (rigidbody.velocity.x > Config.EPS_Velocity)
        {   
            animator.SetBool("Running", true);
            if (! runRight)
            {
                runRight = true;
                rigidbody.transform.localEulerAngles = Vector3.zero;
            }
        }
        else if (rigidbody.velocity.x < -Config.EPS_Velocity)
        {
            animator.SetBool("Running", true);
            if (runRight)
            {
                runRight = false;
                rigidbody.transform.localEulerAngles = Vector3.up * 180;
            }
        }
        else animator.SetBool("Running", false);
    }
}
