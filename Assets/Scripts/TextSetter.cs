using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSetter : MonoBehaviour
{
    private TextMeshPro text;

    public TextMeshPro Text
    {
        get
        {
            if (text == null)
            {
                text = GetComponentInChildren<TextMeshPro>();
            }
            return text;
        }
    }

    public void SetText(string text)
    {
        Text.UpdateText(text);
    }
}
