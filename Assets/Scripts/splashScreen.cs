using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour
{
    [SerializeField] float screenTransition = 2f;

    void Start()
    {
        Invoke("LoadScene", screenTransition);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

}
