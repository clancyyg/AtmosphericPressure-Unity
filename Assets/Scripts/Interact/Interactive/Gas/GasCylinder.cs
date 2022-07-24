using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCylinder : MonoBehaviour
{
    public  float                   HPRestoreExtent = 30f;

    private PlayerComponentManager  player;
    void Awake()
    {
        player  = GameObject.Find("PlayerHandler").GetComponent<PlayerComponentManager>();
    }

    public void OnInteract()
    {
        CollectGasCylinder();
    }
    void CollectGasCylinder()
    {
        gameObject.SetActive(false);
        player.RestoreHP(HPRestoreExtent);
    }
}
