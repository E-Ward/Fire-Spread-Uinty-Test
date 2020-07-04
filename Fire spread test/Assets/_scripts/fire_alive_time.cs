using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_alive_time : MonoBehaviour
{
    public float timeAlive;
    public float maxTimeAlive;
    public float fireDecayTime;
    
    // Start is called before the first frame update
    void Start()
    {
        timeAlive = 0;
        maxTimeAlive = 40;
        fireDecayTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //adds 1 to timeAlive
        timeAlive += 1 * Time.deltaTime;
        
        //if timeAlive is greater than or = to max time then destroy
        if (timeAlive >= maxTimeAlive)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //if the fire enters a non flammable area then the alive time is set to the decay time
        //this means the fire wont stay alight in water
        if (other.tag == "NotFlammable")
        {
            Debug.Log("I am in a non flammable surface \n Putting myself out out");
            float v = maxTimeAlive - fireDecayTime;
            timeAlive = v;
        }
    }
}
