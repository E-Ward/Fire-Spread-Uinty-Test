using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_alive_time : MonoBehaviour
{
    public float timeAlive;
    //public GameObject myself;
    // Start is called before the first frame update
    void Start()
    {
        timeAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += 1 * Time.deltaTime;
        if (timeAlive >= 40)
        {
            Destroy(gameObject);
        }
    }
}
