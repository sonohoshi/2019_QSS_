﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour
{
    //protected Transform transform;
    protected float HP;
    protected float speed;
    protected float DP;
    protected float Power;

    protected void Move()
    {

    }

    protected virtual void Attack()
    {
        
    }

    protected void Begin(float hp, float dp, float sp, float pow)
    {
        HP = hp;
        DP = dp;
        speed = sp;
        Power = pow;
        GetComponent<Rigidbody2D>().mass = DP;
    }

    //HP, DP 등을 불러올 필요가 있을 때는 이걸 씁시다. (캡슐화)
    public float[] GetStats() {
        float[] stat = { HP, speed, DP, Power};
        return stat;
    }
}
