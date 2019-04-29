using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collect : MonoBehaviour {
    private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

    private int nMatchBox;
    private int nGunPowder;
    private int nCoin;
    private int nAcorn;
    private int nSlingshot;
    private int nRubberband;
    public Text MBox;
    public Text GPowder;
    public Text coin;
    public Text acorn;
    public Text slingshot;
    public Text rubberband;
    public Text nextLevel;
    public Text timer;
    float startTimer;
    float t;
    private int minutes;
    private float seconds;
    private bool finish = false;

    public AudioClip pickupClip;
	public AudioClip specialClip;
    public GameObject winning;
    public GameObject Timer;
    public GameObject music;
    Timer stopwatch;
    private int minute;
    private float second;
    private int nextScene;
    // Use this for initialization
    void Start () {

        startTimer = Time.time;

        nMatchBox = 0;
        nGunPowder = 0;
        nCoin = 0;
        nAcorn = 0;
        nSlingshot = 0;
        nRubberband = 0;
        
        timer.text = "";
        winning.SetActive(false);
        MBox.text = nMatchBox.ToString() + "/ 1";
        GPowder.text = nGunPowder.ToString() + "/ 10";
        coin.text = nCoin.ToString() + "/ 20";
        acorn.text = nAcorn.ToString() + "/ 10";
        slingshot.text = nSlingshot.ToString() + "/ 1";
        rubberband.text = nRubberband.ToString() + "/ 1";
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;

    }
	
	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
    private void Update()
    {
        if (finish)
            return;

        t = Time.time - startTimer;

        minutes = ((int)t / 60);
        seconds = (t % 60);
    }

    //player collects the items and the count goes up by one 
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("MatchBox"))
        {
            other.gameObject.SetActive(false);
            nMatchBox += 1;
            MBox.text = nMatchBox.ToString() + "/ 1";
			source.PlayOneShot (pickupClip);
        }
        if(other.gameObject.CompareTag("Powder"))
        {
            other.gameObject.SetActive(false);
            nGunPowder += 1;
            GPowder.text = nGunPowder.ToString() + "/ 10";
			source.PlayOneShot (pickupClip);
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            nCoin += 1;
            coin.text = nCoin.ToString() + "/ 20";
            source.PlayOneShot(pickupClip);
        }
        if (other.gameObject.CompareTag("Acorn"))
        {
            other.gameObject.SetActive(false);
            nAcorn += 1;
            acorn.text = nAcorn.ToString() + "/ 10";
            source.PlayOneShot(pickupClip);
        }
        if (other.gameObject.CompareTag("Slingshot"))
        {
            other.gameObject.SetActive(false);
            nSlingshot += 1;
            slingshot.text = nSlingshot.ToString() + "/ 1";
            source.PlayOneShot(pickupClip);
        }
        if (other.gameObject.CompareTag("Rubberband"))
        {
            other.gameObject.SetActive(false);
            nRubberband += 1;
            rubberband.text = nRubberband.ToString() + "/ 1";
            source.PlayOneShot(pickupClip);
        }

        if (nMatchBox == 1 && nGunPowder == 10 && other.gameObject.CompareTag("Win") || nCoin == 20 && other.gameObject.CompareTag("Win") || nAcorn == 10 && nSlingshot == 1 && nRubberband == 1 && other.gameObject.CompareTag("Win"))
        {
            //nextLevel.text = "You have beat Level ";
            if (winning == null && timer == null)
            {
                SceneManager.LoadScene(7);
                Debug.Log("NextScene");
            }
            else
            {
                winning.SetActive(true);
                Time.timeScale = 0;
                music.SetActive(false);
                finish = true;

                timer.text = "Time:" + minutes.ToString() + ":" + seconds.ToString("f2");
                PlayerPrefs.SetInt("Minutes", minutes);
                PlayerPrefs.SetFloat("Seconds", seconds);

                source.PlayOneShot(specialClip);
            }
        }
    }

}
