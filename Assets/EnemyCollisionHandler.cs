using UnityEngine;

[DisallowMultipleComponent] //disables multiple script on object
public class EnemyCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("enemy is hit");
    }
}
