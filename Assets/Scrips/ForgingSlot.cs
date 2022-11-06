using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgingSlot : MonoBehaviour
{
    [SerializeField] private int number = 0;

    public int hittedPoint = 0;
    public int hittedPointerMax = 100;
    public int safeAreaWidth = 10;
    public int safeAreaCenter = 80;
    public int excellentAreaWidth = 3;
    public int excellentAreaCenter = 80;

    [SerializeField] private EventName eventPointerOn;
    [SerializeField] private EventName eventPointerOff;
    [SerializeField] private EventName eventPointerClicked;

    [SerializeField] private ForgingGauge forgingGauge;

    public bool pointerOn = false;

    private void Start()
    {
        forgingGauge.Initialize(hittedPoint,
            hittedPointerMax,
            safeAreaWidth,
            safeAreaCenter,
            excellentAreaWidth,
            excellentAreaCenter);
    }

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

    public void OnPointerClicked()
    {
        EventManager.TriggerEvent(eventPointerClicked, number.ToString());
    }

    public bool IsPointerOn()
    {
        return pointerOn;
    }

    public void Bash(int hitPoint)
    {
        hittedPoint += hitPoint;
        forgingGauge.UpdatePoint(hittedPoint);
    }
}
