﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverVoltPenetration : MonoBehaviour
{
    private float penetrationSize = 50;
    private float bulletDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            penetrationSize -= collision.attachedRigidbody.mass;

            if (penetrationSize <= 0) gameObject.SetActive(false);
        }
        if(collision.gameObject.CompareTag("Wall")) gameObject.SetActive(false);
    }
    public void SetPenetrationSize()
    {
        penetrationSize = 50;
    }
    
    public void DamageInitialize(float damage)
    {
        bulletDamage = damage;
    }

    public float GetBulletDamage()
    {
        return bulletDamage;
    }
}
