using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private KeyboardMapping KeyboardMapping;

    void Start()
    {
        KeyboardMapping = GetComponent<KeyboardMapping>();
    }

    public bool GetJumpDown() { return Input.GetKeyDown(KeyboardMapping.TriggerToJump); }
    public float GetRun()
    {
        return (Input.GetKey(
            KeyboardMapping.RunRightward
        ) ? 1 : 0) - (Input.GetKey(
            KeyboardMapping.RunLeftward
        ) ? 1 : 0);
    }

    public bool GetJet_Key() { return Input.GetKey(KeyboardMapping.PressToJet_Key); }
    public bool GetJet_Mouse() { return Input.GetMouseButton(KeyboardMapping.PressToJet_Mouse); }

    public bool GetInteractDown() { return Input.GetKey(KeyboardMapping.TriggerToInteract); }
    public bool GetUseWeapon() { return Input.GetKey(KeyboardMapping.PressToUseWeapon); }
    public bool GetDiscardWeaponDown() { return Input.GetKeyDown(KeyboardMapping.TriggerToDiscardWeapon); }
}
