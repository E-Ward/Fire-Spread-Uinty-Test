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

    //public Transform mySize;

    public bool onFire;

    //Colour changing variables
    public Color startingColor, endColor;

    Color currentcolor;
    MeshRenderer myRenderer;

    public float fireColourChangeTime;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the bool onFire to false 
        //don't want to start on fire!!!
        onFire = false;

        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = startingColor;

        //sets the current color to the starting color
        currentcolor = startingColor;

        fireColourChangeTime = .01f;
    }

    // Update is called once per frame
    void Update()
    {
        isColliding = false;

        if (onFire == true)
        {
            if(currentcolor == startingColor)
            {
                currentcolor = endColor;
            }

            // Can be used here if the color needs to be changed back to the starting color
            /*else
            {
                currentcolor = startingColor;
            }*/
        }
        myRenderer.material.color = Color.Lerp(myRenderer.material.color, currentcolor, fireColourChangeTime);
    }
    
    
    IEnumerator fireSpread()
    {
        
        while (fireCount < 20)
        {
            //gets the current position of the object
            Vector3 currentPos = transform.position;

            //gets the current size of the object and devides by 2
            Vector3 range = transform.localScale / 2;

            //sets a random x and y pos within the local scale
            currentPos.x = Random.Range(currentPos.x - range.x, currentPos.x + range.x);
            currentPos.z = Random.Range(currentPos.z - range.z, currentPos.z + range.z);
            //sets y to zero so there is no floating fire
            currentPos.y = 0;

            //spawns the fire at the random pos
            Instantiate(miniFire, currentPos, Quaternion.identity);
            //waits to continue
            yield return new WaitForSeconds(1.5f);
            //adds 1 to the count
            fireCount += 1;
            

        }
    }

    void OnTriggerEnter(Collider other)
    {
        //This check is here to make sure there isn't more than on collision detection
        //I was having problems with the sphere collider activating the trigger more than once
        if (isColliding) return;
        isColliding = true;

        //If the fire enters and the object isn't currently on fire then start the fire spread
        //and set the bool onFire to true so the new fire spawning doesnt activate multiple times
        if(other.tag == "SmallFire" && onFire == false)
        {
            Debug.Log("the fire has entered me, help!!!!!!");
            StartCoroutine(fireSpread());
            onFire = true;
        }
    }
}
