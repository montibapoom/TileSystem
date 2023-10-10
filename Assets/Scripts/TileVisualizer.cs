using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileVisualizer : TouchInteractionBase
{
    [SerializeField]
    private Renderer tileRenderer;
    [SerializeField]
    private Color highlightColor;
    [SerializeField]
    [Range(0.1f, 10f)]
    private float colorChangeDelta = 0.1f;

    private Material tileMaterial;
    private Color defaultColor;
    private float currentColor = 0f;

    private void Start()
    {
        tileMaterial = tileRenderer.material;
        defaultColor = tileRenderer.material.color;
    }

    public override void OnTouch()
    {
        currentColor += colorChangeDelta * Time.deltaTime;
        currentColor = Mathf.Clamp(currentColor, 0f, 1f);
        ChangeColor(currentColor);
    }

    public override void OnUntouch()
    {
        currentColor -= colorChangeDelta * Time.deltaTime;
        currentColor = Mathf.Clamp(currentColor, 0f, 1f);
        ChangeColor(currentColor);
    }
    private void ChangeColor(float fillAmount)
    {
        var targetColor = Color.Lerp(defaultColor, highlightColor, fillAmount);

        if (tileMaterial.color != targetColor)
        {
            tileMaterial.color = targetColor;
        }
    }
}
