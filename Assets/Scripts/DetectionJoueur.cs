using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionJoueur : MonoBehaviour
{
    public GameObject ennemy;
    public EnnemyScript ennemy1Script;
    void Start()
    {
        ennemy1Script = (EnnemyScript)ennemy.GetComponent("Ennemy1Script");
    }
    
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Detected");
            if (ennemy != null) ennemy1Script.Attack();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (ennemy != null) ennemy1Script.StopFire();
    }
}
