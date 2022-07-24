using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasGun : MonoBehaviour
{
    private bool        isObtained = false;
    private Transform   parent;
    private Transform   lastParent;
    private GameObject  sensor;
    private GameObject  Impact;
    private InputSystem inputSystem;
    void Awake()
    {
        sensor          = transform.Find("Sensor").gameObject;
        Impact          = transform.Find("Impact").gameObject;
        inputSystem     = GameObject.Find("InputHandler").GetComponent<InputSystem>();
        parent          = GameObject.Find("PlayerHandler").transform.Find("WeaponHandler");
    }
    void Update()
    {
        // Use Gun
        if (isObtained && inputSystem.GetUseWeapon())
            Impact.SetActive(true);
        else Impact.SetActive(false);

        // Discard Gun
        if (isObtained && inputSystem.GetDiscardWeaponDown()) Discard();
    }
    public void OnInteract()
    {
        Obtain();
    }
    private void Obtain()
    {
        lastParent = transform.parent;

        isObtained = true;
        sensor.SetActive(false);
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<CapsuleCollider2D>().enabled = false;
    }
    private void Discard()
    {
        isObtained = false;
        sensor.SetActive(true);
        transform.SetParent(lastParent);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
