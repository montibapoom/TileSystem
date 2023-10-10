using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursor : MonoBehaviour
{
    public GameObject cursorPrefab;
    private Ray TouchRay => Camera.main.ScreenPointToRay(Input.mousePosition);

    public static Vector3 interactionPoint;

    private GameObject cursorInstance;

    private void Start()
    {
        cursorInstance = Instantiate(cursorPrefab, this.transform);
    }

    private void Update()
    {
        cursorInstance.transform.position = interactionPoint;
        //Debug.Log(interactionPoint);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(Camera.main.transform.position, TouchRay.origin * 100f, Color.yellow);
        Debug.DrawLine(Camera.main.transform.position, TouchRay.direction * 100f, Color.red);
    }
}
