﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] float bulletForce;
    [SerializeField] int damage;

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, bulletForce * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<Player>().Damaged(damage);
            
            if (other.GetComponent<PlayerAbilities>().canBeDamaged)
            {
                other.GetComponent<Player>().Damaged(damage);
                Destroy(this.gameObject);
            }
        }

        if (other.CompareTag("Limit"))
        {
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Shield"))
        {
            bulletForce = bulletForce/2;
            Debug.Log("dentro");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            bulletForce = bulletForce * 2;
            Debug.Log("fuera");
        }
    }
}
