using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // Variables
    // joueur
    [SerializeField] private float pvs = 100f;
    
    // fonction de mouvement
    private Transform cubeTransform;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;
    private float rotateAxis;
    private float moveAxis;

    // fonction de charge
    private bool isCharging = false;
    private bool chargeReady = false;
    private float chargeTime = 0f;
    [SerializeField]private float maxCharge = 3f;
    
    //UI
    public UIDocument inGameDocument;
    public ProgressBar pvsBar;
    public ProgressBar chargeBar;
    
    // fonction de tir
    [SerializeField] private GameObject projectileClassique;
    [SerializeField] private GameObject projectileLourd;
    [SerializeField] private GameObject parent;
    [SerializeField] public float shootCooldown = 3;
    public float timer = 0;
    
    //Respawn
    [SerializeField] private Transform spawnTransform;
    
    // Getting the transform component
    void Start()
    {
        //Reference to UI Document
        var root = inGameDocument.rootVisualElement;
        pvsBar = root.Q<ProgressBar>("Pvs");
        chargeBar = root.Q<ProgressBar>("ChargeBar");

        pvsBar.value = pvs;
        chargeBar.value = chargeTime;
            
        //Reference to component
        cubeTransform = GetComponent<Transform>();
    }
    
    private void Update()
    {
        // Charge Time
        if (isCharging && !chargeReady)
        {
            chargeTime += Time.deltaTime;
        }
        if (chargeTime >= maxCharge)
        {
            Debug.Log("charge Ready");
            chargeReady = true;
        }
        
        //Falling
        if (cubeTransform.position.y <= -14)
        {
            cubeTransform.position = spawnTransform.position;
            cubeTransform.rotation = spawnTransform.rotation;
        }
        
        // Dying
        if (pvs <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Rotating and Moving the tank
    private void FixedUpdate()
    {
        cubeTransform.Rotate(new Vector3(0, 1, 0), rotateAxis * rotationSpeed * Time.deltaTime);
        cubeTransform.Translate(new Vector3(0, 0, 1) * (moveAxis * moveSpeed * Time.deltaTime));
        timer += Time.deltaTime;
    }
    
    // Input from player
    // Move
    public void HandleMove(InputAction.CallbackContext moveInput)
    {
        moveAxis = moveInput.ReadValue<float>();
    }

    // Rotate
    public void HandleRotate(InputAction.CallbackContext rotateInput)
    {
        rotateAxis = rotateInput.ReadValue<float>();
    }

    // Shoot
    public void HandleShoot(InputAction.CallbackContext shootInput)
    {
        if (shootInput.started)
        {
            if (chargeReady && isCharging)
            {
                if (timer >= shootCooldown)
                {
                    Instantiate(projectileLourd, parent.transform.position, parent.transform.rotation);
                    Debug.Log("Je tire une balle lourde");
                    timer = 0;
                }
            }
            else if (timer >= shootCooldown)
            {
                    Instantiate(projectileClassique, parent.transform.position, parent.transform.rotation);
                    Debug.Log("Je tire une balle classique");
                    timer = 0;
            }

            chargeTime = 0f;
            chargeReady = false;
        }
    }

    // Charge
    public void HandleCharge(InputAction.CallbackContext chargeInput)
    {
        isCharging = chargeInput.performed;
        if (!chargeReady)
            Debug.Log(isCharging ? "Charging" : "Stop Charge");
        if (chargeInput.canceled && !chargeReady)
            chargeTime = 0f;
    }
    
    // Ending Level & Taking Damage
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("baballe"))
        {
            pvs -= 10;
        }

        Debug.Log("pvs = " + pvs);
    }
}