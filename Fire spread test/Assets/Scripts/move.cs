using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public Transform pointA, pointB;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        speed = 10 * Time.deltaTime;
        transform.position = Vector3.Lerp(pointA.position, pointB.position, speed);
    }
}
