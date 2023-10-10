using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TouchInteractionBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public PointerEventData OnEnterEventData { get; private set; }
    public PointerEventData OnExitEventData { get; private set; }

    private bool pointerEntered = false;

    private void Update()
    {
        if (pointerEntered)
            OnTouch();
        else
            OnUntouch();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnterEventData = eventData;
        pointerEntered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnExitEventData = eventData;
        pointerEntered = false;
    }

    public abstract void OnTouch();
    public abstract void OnUntouch();
}
