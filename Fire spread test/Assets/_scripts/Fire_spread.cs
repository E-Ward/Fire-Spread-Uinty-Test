using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Fire_spread : MonoBehaviour
{
    public GameObject miniFire;
    //public int xPos;
    //public int zPos;
    public int fireCount;
    public float radius;
    public float startingRadius;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fireSpread());
        radius = startingRadius;

    }

    IEnumerator fireSpread()
    {
        

        while (fireCount < 300)
        {
            //Gets the current pos 
            Vector3 currentPos = transform.position;
            
            //Sets the x and z axis of the current pos to a random point inside the sphere
            currentPos.x = Random.insideUnitSphere.x * radius + currentPos.x;
            currentPos.z = Random.insideUnitSphere.z * radius + currentPos.z;
            //Sets y axis to 0 so no floating fire
            currentPos.y = 0;

            //creates the object to check if the fire can spawn at the current pos
            Instantiate(miniFire, currentPos, Quaternion.identity);
            //waits for .1 of second
            yield return new WaitForSeconds(.1f);

            //adds one to the fireCount
            fireCount += 1;

            //if the radius is less than 13 increase the rdius by .09 every second
            //13 seemed a good radius for the amount of fire being spawned
            if (radius <= 13)
            {
                radius += 10f * Time.deltaTime;
            }
            

        }
    }
}
