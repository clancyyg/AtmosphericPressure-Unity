using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [Header("跟随参数")]
    public  float                   CameraFollowLerp        = 0.01f;
    public  float                   CameraFollowDelayX      = 5f;
    public  float                   CameraFollowDelayY      = 2f;

    public  PlayerComponentManager  player;

    void Awake()
    {
        player                      = GameObject.Find
                                    (
                                        "PlayerHandler"
                                    ).GetComponent<PlayerComponentManager>();
    }

    void LateUpdate()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) > CameraFollowDelayX)
        {
            transform.position = new Vector3
            (
                Mathf.Lerp(transform.position.x, player.transform.position.x, CameraFollowLerp),
                transform.position.y,
                transform.position.z
            );
        }
        if (Mathf.Abs(transform.position.y - player.transform.position.y) > CameraFollowDelayY)
        {
            transform.position = new Vector3
            (
                transform.position.x,
                Mathf.Lerp(transform.position.y, player.transform.position.y, CameraFollowLerp),
                transform.position.z
            );
        }
    }
}
