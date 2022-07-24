using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStation : MonoBehaviour
{
    private PlayerComponentManager  player;
    void Awake()
    {
        player  = GameObject.Find("PlayerHandler").GetComponent<PlayerComponentManager>();
    }

    public void OnInteract()
    {
        UseGasStation();
    }
    void UseGasStation()
    {
        player.RestoreHP(player.HPInitialValue);
    }
}
