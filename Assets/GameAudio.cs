using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    private void Awake()
    {
        int numGameAudio = FindObjectsOfType<GameAudio>().Length; // checks if how many instances in the scene

        if (numGameAudio > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }

}
