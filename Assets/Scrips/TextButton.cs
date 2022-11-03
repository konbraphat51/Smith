using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextButton : MonoBehaviour
{
    [SerializeField] private EventName eventName;
    [SerializeField] private string param;

    [SerializeField] private GameObject selectedEffectObject;

    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void SetSelected(bool selected)
    {
        selectedEffectObject.SetActive(selected);
    }

    public void OnPointerClicked()
    {
        EventManager.TriggerEvent(eventName.n, param);
    }

    public void OnPointerOn()
    {
        textMesh.color = Color.red;
    }

    public void OnPointerOff()
    {
        textMesh.color = Color.black;
    }
}
