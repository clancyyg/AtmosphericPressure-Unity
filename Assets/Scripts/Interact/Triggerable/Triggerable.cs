using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour
{
    // void OnTriggerStay2D(Collider2D other)
    // {
    //     SendMessageUpwards("SensorTriggerStay");
    // }
    void OnTriggerEnter2D(Collider2D other)
    {
        SendMessageUpwards("SensorTriggerEnter");
    }
    void OnTriggerExit2D(Collider2D other)
    {
        SendMessageUpwards("SensorTriggerExit");
    }
}
