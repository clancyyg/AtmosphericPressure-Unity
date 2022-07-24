using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrockenDoors : MonoBehaviour
{
    public void OnImpact()
    {
        gameObject.SetActive(false);
    }
}
