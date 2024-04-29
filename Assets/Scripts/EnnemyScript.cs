using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class EnnemyScript : MonoBehaviour
{
    // Variable
    // for ending level once defeated
    [SerializeField] private int pvs;

    // ATTACKING
    // for rotation
    [SerializeField] private Transform tourelle;
    [SerializeField] private GameObject player;
    private Vector3 lookPos = new Vector3();
    [SerializeField] private float smoothTime;
    
    // for shoot
    private Animator animator;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float frameRate;
    [SerializeField] private float distanceShoot;
    [SerializeField] private LevelManager Script;

    private Coroutine FireCoroutine;
    
    public event Action<GameObject> IsDead;
    void Start()
    {
        animator = GetComponent<Animator>();
        IsDead += Script.EnnemyDead;
    }

    // Dying
    void Update()
    {
        if (pvs <= 0)
        {
            IsDead?.Invoke(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    // Taking Damage
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("baballeJoueur"))
        {
            pvs -= 10;
        }
        else if (collider.gameObject.CompareTag("baballeLourde"))
        {
            pvs -= 20;
        }

        Debug.Log("pvs = " + pvs);
    }

    // Attack
    public void Attack()
    {
        Vector3 velocity = Vector3.zero;
        lookPos = Vector3.SmoothDamp(lookPos, player.transform.position, ref velocity, smoothTime);
        if (tourelle != null) tourelle.LookAt(lookPos, Vector3.up);

        if (Vector3.Distance(lookPos, player.transform.position) < distanceShoot)
        {
            StartFire();
        }
        else
        {
            StopFire();
        }
    }
    // Coroutine
    public void StartFire()
    {
        if (FireCoroutine is null)
        {
            Debug.Log("Shooting");
            FireCoroutine = StartCoroutine("Fire");
        }
        else
        {
            Debug.Log("Shooting Denied");
        }
    }

    public void StopFire()
    {
        Debug.Log("Stop Shooting");
        StopCoroutine("Fire");
        FireCoroutine = null;
    }

    private IEnumerator Fire()
    {
        do
        {
            Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
            yield return new WaitForSeconds(frameRate);
        } while (true);
    }
}