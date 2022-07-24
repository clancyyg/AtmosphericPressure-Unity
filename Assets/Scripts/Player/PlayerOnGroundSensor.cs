using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGroundSensor : MonoBehaviour
{
    public GameObject OnTrigger { get; private set; }

    private void OnTriggerStay2D(Collider2D other)
    {
        OnTrigger = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        OnTrigger = null;
    }
}
