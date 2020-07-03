using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flammable : MonoBehaviour
{
    public GameObject miniFire;
    public int fireCount;
    //public BoxCollider myCollider;

    //float colliderX;
    //float colliderZ;

    public bool isColliding;

    public Transform mySize;

    public bool onFire;

    // Start is called before the first frame update
    void Start()
    {
        onFire = false;
       
        //myCollider = GetComponent<BoxCollider>();



        //colliderX = myCollider.size.x;
        //colliderZ = myCollider.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        isColliding = false;
    }
    IEnumerator fireSpread()
    {
        
        while (fireCount < 20)
        {
            
            Vector3 currentPos = transform.position;
            Vector3 range = transform.localScale / 2;

            

            currentPos.x = Random.Range(currentPos.x - range.x, currentPos.x + range.x);
            currentPos.z = Random.Range(currentPos.z - range.z, currentPos.z + range.z);
            currentPos.y = 0;

            //xPos = Random.Range(-2, 2);
            //zPos = Random.Range(-2, 2);
            Instantiate(miniFire, currentPos, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
            fireCount += 1;
            

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isColliding) return;
        isColliding = true;
        if(other.tag == "SmallFire" && onFire == false)
        {
            Debug.Log("the fire has entered me, help!!!!!!");
            StartCoroutine(fireSpread());
            onFire = true;
        }
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SmallFire")
        {
            Debug.Log("the fire has entered me, help!!!!!!");
        }
    }*/
}
