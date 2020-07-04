using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_fire_script : MonoBehaviour
{
    public GameObject miniFire;
    public int xPos;
    public int zPos;
    public int fireCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fireSpread());

    }

    IEnumerator fireSpread()
    {
        while (fireCount < 2)
        {
            Vector3 currentPos = transform.position;
            //currentPos.x = Random.Range(currentPos.x - 2, currentPos.x + 2);
            //currentPos.z = Random.Range(currentPos.z - 2, currentPos.z + 2);

            currentPos.x = Random.insideUnitSphere.x * 2;
            currentPos.z = Random.insideUnitSphere.z * 2;
            currentPos.y = 0;

            //xPos = Random.Range(-2, 2);
            //zPos = Random.Range(-2, 2);
            Instantiate(miniFire, currentPos, Quaternion.identity);
            yield return new WaitForSeconds(2f);
            fireCount += 1;

        }
    }
}
