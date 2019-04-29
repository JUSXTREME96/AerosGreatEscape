using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class Video : MonoBehaviour {
    public MovieTexture movie;
    private int nextScene;
    public GameObject intruct;
    public static bool isPaused = false;


  
    RawImage rawVideo;
    AudioSource videoSound;
    // Use this for initialization
    void Start() {
       
        rawVideo = GetComponent<RawImage>();
        videoSound = GetComponent<AudioSource>();
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        intruct.SetActive(false);
        PlayVideo();
    }

    void PlayVideo()
    {
        rawVideo.texture = movie;
        movie.Play();
        videoSound.clip = movie.audioClip;
        videoSound.Play();
        Invoke("EnableText", 7f);
        
    }
    private void Update()
    {
        if (!movie.isPlaying)
        {
            SceneManager.LoadScene(nextScene);
        }

        if (movie.isPlaying)
        {
            if (Input.anyKey || Input.GetKeyDown("joystick button 2"))
            {
                movie.Stop();
                SceneManager.LoadScene(nextScene);
            }
        }
    }
    private void EnableText()
    {
        intruct.SetActive(true);
    }
}
