using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    bool        onceLock        = false;
    private     InputSystem     InputSystem;
    void Start()
    {
       InputSystem              = GameObject.Find
                                (
                                    "InputHandler"
                                ).GetComponent<InputSystem>(); 
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (InputSystem.GetInteractDown())
        {
            if (! onceLock)
            {
                onceLock = true;
                SendMessageUpwards("OnInteract");
            }
        }
        else onceLock = false;
    }
}
