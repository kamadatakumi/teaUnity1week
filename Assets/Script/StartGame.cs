using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
    GameObject titletext1;
    GameObject titletext2;
    GameObject titletext3;
    GameObject titleimage;
    float delta=0;
    bool key=false;
    float a = 0.1f;

	// Use this for initialization
	void Start () {
        titletext1 = GameObject.Find("Title1");
        titletext2 = GameObject.Find("Title2");
        titletext3 = GameObject.Find("Description");
        titleimage= GameObject.Find("TitleDes");

        titletext3.GetComponent<Text>().enabled = false;
        titleimage.GetComponent<Image>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            titletext1.GetComponent<Text>().enabled = false;
            titletext2.GetComponent<Text>().enabled = false;
            titletext3.GetComponent<Text>().enabled = true;
            titleimage.GetComponent<Image>().enabled = true;

            key = true;
        }
            if (key==true)
            {
                delta += Time.deltaTime;
            }
            if (a < delta)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene("Game");
                }
            }
        
	}
}
