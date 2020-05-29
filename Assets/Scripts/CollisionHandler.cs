using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX on player")][SerializeField] GameObject deathFx;

    private void OnTriggerEnter(Collider other)
    {
        deathFx.SetActive(true);
        playerHitHandler();
    }

    private void playerHitHandler()
    {
        print("Im hit!");
        SendMessage("PlayerIsHit", true); //invoke method on other script that is attached to the object
        Invoke("ReloadScene", levelLoadDelay); //calls method on the class on specified time
    }

    private void ReloadScene() // called by reference string
    {
        SceneManager.LoadScene(1);
    }


}
