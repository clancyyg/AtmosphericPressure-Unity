using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    public  float           MoveVelocity = 5f;
    public  bool            MoveUpward = false;
    public  bool            MoveDownward = false;
    public  bool            MoveLeftward = false;
    public  bool            MoveRightward = false;

    private bool            autoMoveLock = false;
    private Vector3         initialPosition;
    private new Rigidbody2D rigidbody;

    void Start()
    {
        initialPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (autoMoveLock)
        {
            Vector3 direction = Vector3.zero;

            if (MoveUpward) direction = Vector3.up;
            if (MoveDownward) direction = Vector3.down;
            if (MoveLeftward) direction = Vector3.left;
            if (MoveRightward) direction = Vector3.right;
            
            rigidbody.velocity = direction * MoveVelocity;
            return;
        }
        if (MoveUpward)
        {
            if (transform.position.y > initialPosition.y)
                rigidbody.velocity = Vector3.down * MoveVelocity;
            else transform.position = initialPosition;
        }
        if (MoveDownward)
        {
            if (transform.position.y < initialPosition.y)
                rigidbody.velocity = Vector3.up * MoveVelocity;
            else transform.position = initialPosition;
        }
        if (MoveLeftward)
        {
            if (transform.position.x < initialPosition.x)
                rigidbody.velocity = Vector3.right * MoveVelocity;
            else transform.position = initialPosition;
        }
        if (MoveRightward)
        {
            if (transform.position.x > initialPosition.x)
                rigidbody.velocity = Vector3.left * MoveVelocity;
            else transform.position = initialPosition;
        }
    }
    public void SensorTriggerEnter() { autoMoveLock = true; }
    public void SensorTriggerExit() { autoMoveLock = false; }
}
