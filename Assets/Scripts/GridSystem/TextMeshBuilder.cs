using TMPro;
using UnityEngine;

public static class TextMeshBuilder
{
    public static TextMeshPro CreateText(string name, string text)
    {
        var obj = new GameObject(name, typeof(TextMeshPro));
        var textMesh = obj.GetComponent<TextMeshPro>();
        textMesh.text = text;

        return textMesh;
    }

    public static TextMeshPro SetParent(this TextMeshPro textMesh, Transform parent = null)
    {
        textMesh.transform.SetParent(parent, false);

        return textMesh;
    }

    public static TextMeshPro SetPosition(this TextMeshPro textMesh, Vector3 position = default)
    {
        textMesh.transform.position = position;
        return textMesh;
    }

    public static TextMeshPro SetLocalPosition(this TextMeshPro textMesh, Vector3 position = default)
    {
        textMesh.transform.localPosition = position;
        return textMesh;
    }

    public static TextMeshPro SetRotation(this TextMeshPro textMesh, Quaternion rotation = default)
    {
        textMesh.transform.rotation = rotation;
        return textMesh;
    }

    public static TextMeshPro SetLocalRotation(this TextMeshPro textMesh, Quaternion rotation = default)
    {
        textMesh.transform.localRotation = rotation;
        return textMesh;
    }

    public static TextMeshPro SetAlignment(this TextMeshPro textMesh, TextAlignmentOptions alignment = TextAlignmentOptions.Center)
    {
        textMesh.alignment = alignment;
        return textMesh;
    }

    public static TextMeshPro SetFontSize(this TextMeshPro textMesh, float fontSize = 40f)
    {
        textMesh.fontSize = fontSize;
        return textMesh;
    }

    public static TextMeshPro SetColor(this TextMeshPro textMesh, Color color = default)
    {
        textMesh.color = color;
        return textMesh;
    }

    public static TextMeshPro SetSortingOrder(this TextMeshPro textMesh, int sortingOrder = 5000)
    {
        var mesh = textMesh.GetComponent<MeshRenderer>();
        mesh.sortingOrder = sortingOrder;
        return textMesh;
    }

    public static void UpdateText(this TextMeshPro textMesh, string text)
    {
        if (textMesh.text != text)
        {
            textMesh.text = text;
        }
    }
}