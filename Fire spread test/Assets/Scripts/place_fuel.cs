using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class place_fuel : MonoBehaviour
{
    public Transform ground;
    public Material trailMaterial;

    private Rigidbody rb;
    private Collider groundCollider;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCollider = ground.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.X))
        {
            Vector3 closestOnGround = groundCollider.ClosestPointOnBounds(transform.position);
            LeaveTrail(closestOnGround, .1f, trailMaterial);
        }
        
    }

    private void LeaveTrail(Vector3 point, float scale, Material material)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = Vector3.one * scale;
        sphere.transform.position = point;
        sphere.transform.parent = transform.parent;
        sphere.GetComponent<Collider>().enabled = false;
        sphere.GetComponent<Renderer>().material = material;
        Destroy(sphere, 10f);
    }
}
