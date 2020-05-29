using System;
using UnityEngine;

[DisallowMultipleComponent] //disables multiple script on object
public class EnemyCollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12; //default score per hit, can be changed on gameobject

    ScoreBoard scoreBoard; //reference to ScoreBoard script

    GameObject fxHolder;

    void Start()
    {
        addNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>(); //find and place the ScoreBoard script to placeholder
    }

    private void addNonTriggerBoxCollider()
    {
        Collider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);
        GenerateDeathFX();
        Destroy(gameObject);
    }

    private void GenerateDeathFX()
    {
        fxHolder = Instantiate(deathFX, transform.position, Quaternion.identity);
        fxHolder.transform.parent = parent;
    }
}
