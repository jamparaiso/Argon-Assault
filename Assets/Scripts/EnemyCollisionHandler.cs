using System;
using UnityEngine;

[DisallowMultipleComponent] //disables multiple script on object
public class EnemyCollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    GameObject fxHolder;

    void Start()
    {
        addNonTriggerBoxCollider(); 
    }

    private void addNonTriggerBoxCollider()
    {
        Collider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        fxHolder = Instantiate(deathFX,transform.position,Quaternion.identity);
        fxHolder.transform.parent = parent;
        Destroy(gameObject);
    }
}
