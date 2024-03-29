using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Variables
    private Transform cubeTransform;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;

    private float rotateAxis;
    private float moveAxis;

    private bool isCharging = false;
    [SerializeField]private float chargeTime = 0f;
    [SerializeField]private float maxCharge = 3f;
    private bool canCharge = true;
    
    // Before other functions
    void Start()
    {
        cubeTransform = GetComponent<Transform>();
    }
    
    // Once per frame
    private void Update()
    {
        if (isCharging && canCharge)
            chargeTime += 1 * Time.deltaTime;
        if (!(chargeTime >= maxCharge)) return;
        Debug.Log("Charge ready");
        chargeTime = 0f;
        canCharge = false;
    }

    // Better for physics thingys
    private void FixedUpdate()
    {
        cubeTransform.Rotate(new Vector3(0, 1, 0), rotateAxis * rotationSpeed * Time.deltaTime);
        cubeTransform.Translate(new Vector3(0, 0, 1) * (moveAxis * moveSpeed * Time.deltaTime));
    }

    
    // Input Actions
    public void HandleMove(InputAction.CallbackContext moveInput)
    {
        moveAxis = moveInput.ReadValue<float>();
    }

    public void HandleRotate(InputAction.CallbackContext rotateInput)
    {
        rotateAxis = rotateInput.ReadValue<float>();
    }

    public void HandleShoot(InputAction.CallbackContext shootInput)
    {
        if (!shootInput.started) return;
        canCharge = true;
        Debug.Log("Je tire !!!");
    }

    public void HandleCharge(InputAction.CallbackContext chargeInput)
    {
        isCharging = chargeInput.performed;
        Debug.Log(isCharging ? "Charging" : "Stop Charge");
        if (chargeInput.canceled)
            chargeTime = 0f;
    }
}