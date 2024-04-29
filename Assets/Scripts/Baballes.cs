using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baballes : MonoBehaviour
{ 
    private float projectileSpeed = 3.5f;
    private float clock;
    [SerializeField] private float lifeTime = 6f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Physics
    void FixedUpdate()
    {
        Vector3 movement = transform.forward * projectileSpeed * Time.deltaTime;
        transform.position = transform.position + movement;
        clock += Time.deltaTime;
        if(clock >= lifeTime)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
