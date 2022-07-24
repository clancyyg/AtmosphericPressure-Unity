using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFanCollider : MonoBehaviour
{
    public void UpdateFanColliderLength(float length)
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.size = new Vector3(length, collider.size.y);
    }
}
