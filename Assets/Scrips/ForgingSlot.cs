using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgingSlot : MonoBehaviour
{
    [SerializeField] private int number = 0;

    [SerializeField] private EventName eventPointerOn;
    [SerializeField] private EventName eventPointerOff;

    public bool pointerOn = false;
    public void OnPointerOn()
    {
        pointerOn = true;
        EventManager.TriggerEvent(eventPointerOn, number.ToString());
    }
    public void OnPointerOff()
    {
        pointerOn = false;  //don't put before TriggerEvent; pointer off check would proceed.
        EventManager.TriggerEvent(eventPointerOff, number.ToString());
    }

    public bool IsPointerOn()
    {
        return pointerOn;
    }
}
