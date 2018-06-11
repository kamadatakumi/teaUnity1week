using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarController : MonoBehaviour {

    public Rigidbody rb;
    float speedx;
    float maxspeed=30;
    bool ab=false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	void Update () {
        speedx = 0;
        {
            if (Input.GetKey(KeyCode.Space) && ab == false)
            {
                speedx = 10f;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                ab = true;
            }


            rb.AddForce(speedx * 2, 0, 0);
            if (maxspeed < speedx)
            {
                speedx -= 5;
            }
        }
    }
}
