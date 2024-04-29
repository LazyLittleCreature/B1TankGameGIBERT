using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tourelle : MonoBehaviour
{
    // Variables
    public Transform tourelleTransform;
    private float rotateAxis;
    [SerializeField] private float rotationSpeed;
    
    // Getting the transform component
    private void Start()
    {
        tourelleTransform = GetComponent<Transform>();
    }

    // Rotating the tower
    private void FixedUpdate()
    {
            tourelleTransform.Rotate(new Vector3(0, 1, 0), rotateAxis * rotationSpeed * Time.deltaTime);
    }

    // Input from player
    public void HandleTourelleRotate(InputAction.CallbackContext rotateInput)
    {
        rotateAxis = rotateInput.ReadValue<float>();
    }
}
