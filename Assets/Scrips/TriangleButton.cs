using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleButton : MonoBehaviour
{
    [SerializeField] private EventName eventPushed;
    [SerializeField] private string param;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnPointerClicked()
    {
        EventManager.TriggerEvent(eventPushed, param);
    }

    public void OnPointerOn()
    {
        spriteRenderer.color = Color.yellow;
    }

    public void OnPointerOff()
    {
        spriteRenderer.color = Color.blue;
    }
}
