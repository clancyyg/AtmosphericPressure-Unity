using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impactive : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        SendMessageUpwards("OnImpact");
    }
}
