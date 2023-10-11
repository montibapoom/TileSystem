using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public Transform objectToRotate;
    public KeyCode yRotationLeft = KeyCode.A;
    public KeyCode yRotationRight = KeyCode.D;

    public float rotationSpeed = 1f;

    private void Update()
    {
        Rotate(objectToRotate);
    }

    private void Rotate(Transform objectToRotate)
    {
        var rotation = objectToRotate.localEulerAngles;

        if (KeyIsPressed(yRotationLeft))
            rotation -= Vector3.up * Time.deltaTime * rotationSpeed;
        else if (KeyIsPressed(yRotationRight))
            rotation += Vector3.up * Time.deltaTime * rotationSpeed;

        if (objectToRotate.localEulerAngles != rotation)
            objectToRotate.localEulerAngles = rotation;
    }

    private bool KeyIsPressed(KeyCode keyCode) => Input.GetKey(keyCode);
}
