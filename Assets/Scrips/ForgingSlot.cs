using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgingSlot : MonoBehaviour
{
    [SerializeField] private int number = 0;

    [SerializeField] private EventName eventPointerOn;

    public void OnPointerOn()
    {
        EventManager.TriggerEvent(eventPointerOn, number.ToString());
    }
}
