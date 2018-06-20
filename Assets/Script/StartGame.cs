using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartGame : MonoBehaviour {
    TextMeshProUGUI titletext1;
    TextMeshProUGUI titletext2;
    TextMeshProUGUI titletext3;
    GameObject titleimage;
    float delta=0;
    bool key=false;
    float a = 0.1f;

	// Use this for initialization
	void Start () {
        titletext1 = GameObject.Find("Title1").GetComponent<TextMeshProUGUI>();
        titletext2 = GameObject.Find("Title2").GetComponent<TextMeshProUGUI>();
        titletext3 = GameObject.Find("Description").GetComponent<TextMeshProUGUI>();
        titleimage = GameObject.Find("TitleDes");

        titletext3.GetComponent<TextMeshProUGUI>().enabled = false;
        titleimage.GetComponent<Image>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            titletext1.GetComponent<TextMeshProUGUI>().enabled = false;
            titletext2.GetComponent<TextMeshProUGUI>().enabled = false;
            titletext3.GetComponent<TextMeshProUGUI>().enabled = true;
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
