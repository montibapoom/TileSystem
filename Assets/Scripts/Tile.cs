using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private TextSetter textSetter;

    public TextSetter TextSetter => textSetter;

    public Vector2Int InboardPosition => this.transform.localPosition.FloorToInt().ConvertPlacementWithAxis(Axis.Horizontal);

    public void OnPointerClick(PointerEventData eventData)
    {
    }
}