using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameDirector : MonoBehaviour {
    GameObject car;
    GameObject flag;
    TextMeshProUGUI range;
    TextMeshProUGUI result;
    GameObject wave;
    TextMeshProUGUI description;
    float delta=0;
    float delta2 = 0;
    bool deltastart=false;
    float spacetime=3.8f;
    float spacetime2 = 1f;
    bool deltastart2 = false;
    float stop;
    AudioSource tin1;
    AudioSource trumpet1;
    bool audios=true;
    bool ranking=true;
    bool ranking2 = false;
    bool ranking3=false;
    TextMeshProUGUI rankingtext;
    
	// Use this for initialization
	void Start () {
        car = GameObject.Find("FuzzyRed");
        flag = GameObject.Find("flag_med");
        range = GameObject.Find("Range").GetComponent<TextMeshProUGUI>();
        result = GameObject.Find("Result").GetComponent<TextMeshProUGUI>();
        result.GetComponent<TextMeshProUGUI>().enabled = false;
        wave = GameObject.Find("Wave2");
        description = GameObject.Find("Description").GetComponent<TextMeshProUGUI>();
        description.GetComponent<TextMeshProUGUI>().enabled = false;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        tin1 = audioSources[2];
        trumpet1 = audioSources[1];
        rankingtext = GameObject.Find("Rankingtext").GetComponent<TextMeshProUGUI>();
        rankingtext.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetSceneByName("Ranking").IsValid())  return; 
        float length = flag.transform.position.x - car.transform.position.x;
        if (length < 0) length *= -1;
            range.GetComponent<TextMeshProUGUI>().text = "ゴールまで" + length.ToString("F2") + "m";

        if (car.transform.position.y > wave.transform.position.y + 20)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                deltastart = true;
            }
            if (deltastart == true)
            { 
            delta += Time.deltaTime;
            }
            if (car.transform.position.y < 0) delta -= Time.deltaTime;
            if (delta > spacetime)
            {
                if (audios == true)
                {
                    GetComponent<AudioSource>().PlayOneShot(tin1.clip);
                    audios = false;
                }
                range.GetComponent<TextMeshProUGUI>().enabled = false;
                result.GetComponent<TextMeshProUGUI>().text = "結果:" + length.ToString("F2") + "m";
                result.GetComponent<TextMeshProUGUI>().enabled = true;
                deltastart2 = true;
                ranking2 = true;
                }
        }
        else
        {
            if (audios == true)
            {
                GetComponent<AudioSource>().PlayOneShot(trumpet1.clip);
                audios = false;
            }
            range.GetComponent<TextMeshProUGUI>().enabled = false;
            result.GetComponent<TextMeshProUGUI>().text = "結果:失敗";
            result.GetComponent<TextMeshProUGUI>().enabled = true;
            deltastart2 = true;
            ranking3 = true;
        }
        if (deltastart2 == true)
        {
            delta2 += Time.deltaTime;
        }
        if (delta2 > spacetime2)
        {
            description.GetComponent<TextMeshProUGUI>().enabled = true;
            if (ranking2 == true)
            {
                rankingtext.GetComponent<TextMeshProUGUI>().enabled = true;
                if (Input.GetKeyDown(KeyCode.T))
                {
                    naichilab.UnityRoomTweet.Tweet("Giri_Car", "Giri Carをやってみたよ。結果は " + length.ToString("F2") + "m でした。みんなもやってみない？", "unityroom", "unity1week");
                }
                if (Input.GetKeyDown(KeyCode.Return)&&ranking2==true)
                {
                        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(length);
                }
            }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("Title");
                }

            if (ranking3 == true)
            {
                rankingtext.GetComponent<TextMeshProUGUI>().text = " 　　　　　　     　ツイート: T";
                rankingtext.GetComponent<TextMeshProUGUI>().enabled = true;

                if (Input.GetKeyDown(KeyCode.T))
                {
                    naichilab.UnityRoomTweet.Tweet("Giri_Car", "Giri Carをやってみたよ。結果は 失敗 でした。みんなもやってみない？", "unityroom", "unity1week");
                }
            }
        }
       
    }
}
