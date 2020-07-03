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
            Vector3 currentPos = transform.position;
            //currentPos.x = Random.Range(currentPos.x - 10, currentPos.x + 10);
            //currentPos.z = Random.Range(currentPos.z - 10, currentPos.z + 10);

            currentPos.x = Random.insideUnitSphere.x * radius + currentPos.x;
            currentPos.z = Random.insideUnitSphere.z * radius + currentPos.z;
            currentPos.y = 0;

            //xPos = Random.Range(-10, 10);
            //zPos = Random.Range(-10, 10);
            Instantiate(miniFire, currentPos, Quaternion.identity);
            yield return new WaitForSeconds(.1f);
            fireCount += 1;

            if (radius <= 13)
            {
                radius += 0.09f;
            }
            

        }
    }
}
