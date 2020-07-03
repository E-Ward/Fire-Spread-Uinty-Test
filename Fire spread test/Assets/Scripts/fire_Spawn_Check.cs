﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_Spawn_Check : MonoBehaviour
{
    public bool isColliding;
    public GameObject fire;

    public float aliveTime;

    // Start is called before the first frame update
    void Start()
    {
        aliveTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        isColliding = false;
        aliveTime += 1 * Time.deltaTime;
        if (aliveTime >=1)
        {
            spawnFire();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 myPos = transform.position;
        if (isColliding) return;
        isColliding = true;

        if(other.tag == "NotFlammable")
        {
            Debug.Log("I hit water!!");
            Destroy(gameObject);
        }
    }

    void spawnFire()
    {
        Vector3 myPos = transform.position;
        Instantiate(fire, myPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
