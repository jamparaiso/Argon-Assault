using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadScene", 5);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

}
