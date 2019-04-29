using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTrigger : MonoBehaviour
{
    private Scene scene;
    public GameObject gameOver;
    public GameObject music;

    void Start()
    {
        scene = SceneManager.GetActiveScene();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameOver.SetActive(true);
            music.SetActive(false);
            Time.timeScale = 0;

        }
    }
   


}