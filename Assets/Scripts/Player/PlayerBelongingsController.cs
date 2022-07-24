using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBelongingsController
{
    // Player Transforms
    private Transform               weapons;
    private PlayerComponentManager  componentManager;

    // Obtain Guns
    private Vector3                     targetColliderSize;
    private Vector3                     targetColliderOffset;
    private Vector3                     initialColliderSize;
    private Vector3                     initialColliderOffset;

    public PlayerBelongingsController
    (
        Transform               weapons,
        PlayerComponentManager  componentManager    
    )
    {
        this.weapons            = weapons;
        this.componentManager   = componentManager;
    }

    public void Init()
    {
        targetColliderSize              = new Vector3(2.6f, 5.6f);
        targetColliderOffset            = new Vector3(-0.36f, 2.73f);
        initialColliderSize             = componentManager.GetComponent<CapsuleCollider2D>().size;
        initialColliderOffset           = componentManager.GetComponent<CapsuleCollider2D>().offset;
    }

    public void Update()
    {
        DetectHasWeaponOverHead();
    }

    private void DetectHasWeaponOverHead()
    {
        if (weapons.childCount > 0)
        {
            componentManager.GetComponent<CapsuleCollider2D>().offset = targetColliderOffset;
            componentManager.GetComponent<CapsuleCollider2D>().size = targetColliderSize;
        }
        else
        {
            componentManager.GetComponent<CapsuleCollider2D>().offset = initialColliderOffset;
            componentManager.GetComponent<CapsuleCollider2D>().size = initialColliderSize;
        }
    }
}
