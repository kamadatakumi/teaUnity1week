using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wavein : MonoBehaviour {
    GameObject range;
    bool wavein = false;
    // Use this for initialization
	void Start () {
        range = GameObject.Find("Range");
	}
	
	// Update is called once per frame
	void Update () {
        if (wavein == true)
        {
            range.GetComponent<Text>().text = "ゴールまで"+ "--.--" + "m"; ;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        wavein = true;
    }
}
