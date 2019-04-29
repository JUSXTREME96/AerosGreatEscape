using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    public AudioSource playSound;
    public AudioSource quitSound;
    public AudioMixer audioMixer;
    public Slider music;
    public Slider sfx;

    private int nextScene;
    private int scene;
    

    // Use this for initialization
    void Start () {
       
        music.value = PlayerPrefs.GetFloat("MusicVolume");
        sfx.value = PlayerPrefs.GetFloat("SFXVolume");
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        scene = SceneManager.GetActiveScene().buildIndex;
        
    }
    private void Update()
    {

    }

    public void PlayGameSound()
    {
            playSound.Play();
            Time.timeScale = 1;
            Invoke("NextScene", 2f);
    }
    public void QuitSound()
    {
        quitSound.Play();
        Invoke("Quit", 1f);
    }

    public void NextScene()
    {
        
        SceneManager.LoadScene(nextScene);
        Debug.Log("new scene" + nextScene);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("I have quit");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SetMValue(float mValue)
    {
        
        PlayerPrefs.SetFloat("MusicVolume", mValue);
        SetMusicVolume();
       
    }
    public void SetSValue(float sValue)
    {
        PlayerPrefs.SetFloat("SFXVolume", sValue);
        SetSFXVolume();
    }

    public void SetMusicVolume()
    {
        music.value = PlayerPrefs.GetFloat("MusicVolume");
        
        //Debug.Log(music.value);
        audioMixer.SetFloat("Music", Mathf.Log10(music.value) * 20);

    }
    public void SetSFXVolume()
    {
        sfx.value = PlayerPrefs.GetFloat("SFXVolume");

        Debug.Log(sfx.value);
        audioMixer.SetFloat("SFX", Mathf.Log10(sfx.value) * 20);

    }
     public void Restart()
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

}

