using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponentManager : MonoBehaviour
{
    [Header("气压")]
    public  float                       AtmosphericPressure = 0;
    [Header("移动")]
    public  float                       RunSpeed        = 10f;
    public  float                       JumpSpeed       = 20f;
    public  float                       JetForce        = 15f;    
    public  float                       JetThrust       = 300f;
    public  float                       RunSpeedLerp    = 0.5f;
    [Header("生命")]
    public  float                       HPInitialValue = 100f;
    public  float                       HPDecreaseUpdateInterval = 0.5f;
    public  float                       HPDecreaseOverTimeExtent = 1.0f;
    public  float                       HPDecreaseWhenJettingExtent = 3f;
    public  float                       HPYellowToRedCriticalPoint = 30f;
    public  float                       HPGreenToYellowCriticalPoint = 80f;

    // Components
    private Animator                    animator;
    private Transform                   weapons;
    private InputSystem                 inputSystem;
    private new Rigidbody2D             rigidbody;

    private PlayerMovementController    motionController;
    private PlayerPropertyController    propertyController;
    private PlayerBelongingsController  belongingsController;
    
    void Awake()
    {
        animator                        = GetComponent<Animator>();
        rigidbody                       = GetComponent<Rigidbody2D>();
        weapons                         = transform.Find("WeaponHandler");
        inputSystem                     = GameObject.Find
                                        (
                                            "InputHandler"
                                        ).GetComponent<InputSystem>();

        motionController                = new PlayerMovementController
                                        (
                                            animator,
                                            rigidbody,
                                            inputSystem,
                                            this
                                        );
        Transform HPHandler             = transform.Find("HPHandler");
        propertyController              = new PlayerPropertyController
                                        (
                                            HPInitialValue,
                                            HPDecreaseUpdateInterval,
                                            HPDecreaseOverTimeExtent,
                                            HPDecreaseWhenJettingExtent,
                                            HPYellowToRedCriticalPoint,
                                            HPGreenToYellowCriticalPoint,

                                            HPHandler.transform.Find("HPBar"),
                                            HPHandler,
                                            this
                                        );
        belongingsController            = new PlayerBelongingsController
                                        (
                                            weapons,
                                            this
                                        );
    }

    void Start()
    {
        belongingsController.Init();
    }

    void Update()
    {
        motionController.Update();
        propertyController.Update();
        belongingsController.Update();
    }

    public void RestoreHP(float value) { propertyController.RestoreHP(value); }
    public bool GetJetting() { return animator.GetBool("Jetting"); }
    public bool GetRunning() { return animator.GetBool("Running"); }
    public bool GetOnGround() { return animator.GetBool("OnGround"); }
}