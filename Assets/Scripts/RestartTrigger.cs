using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTrigger : MonoBehaviour
{
    private Scene scene;
    public GameObject gameOver;

    void Start()
    {
        scene = SceneManager.GetActiveScene();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Application.LoadLevel(scene.name);
        }
    }

}