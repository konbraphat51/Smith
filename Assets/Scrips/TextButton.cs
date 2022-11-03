using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextButton : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();        
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
