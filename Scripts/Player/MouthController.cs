using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouthController : MonoBehaviour
{
    // Dependancies
    public GameObject wolf;
    public GameObject projectilePrefab;
    
    // Adjustable
    public float speed = 3.0f;

    // Attack pattern
    private float _borkCD = 0.25f;
    private float _borkTimer;
    private void Start()
    {
        _borkTimer = 0.0f;
    }

    private void Update()
    {
        _borkTimer -= Time.deltaTime;
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (_borkTimer < 0)
            {
                GameObject projectile = Instantiate<GameObject>(projectilePrefab);
                projectile.transform.position = this.transform.position;
                projectile.transform.rotation = this.transform.rotation;
                projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
                SoundController.PlaySound("Bork");

                wolf.GetComponent<WolfController>().isBorking = true;
                _borkTimer = _borkCD;
            }
            
        }
        
    }

    
}
