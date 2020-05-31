using System;
using UnityEngine;

[DisallowMultipleComponent] //disables multiple script on object
public class EnemyCollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] float enemyHP = 3f;

    ScoreBoard scoreBoard; //reference to ScoreBoard script

    GameObject fxHolder;

    void Start()
    {
        addNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>(); //find and place the ScoreBoard script to placeholder
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (enemyHP <= 0)
        {
            KillEnemy();
        }

    }

    private void ProcessHit()
    {
        updateScore(scorePerHit);
        enemyHP = enemyHP - 1;
    }

    private void updateScore(int score)
    {
        scoreBoard.ScoreHit(score);
    }

    private void KillEnemy()
    {
        updateScore(scorePerHit * 2);
        GenerateDeathFX();
        Destroy(gameObject);
    }
    private void addNonTriggerBoxCollider()
    {
        Collider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }
    private void GenerateDeathFX()
    {
        fxHolder = Instantiate(deathFX, transform.position, Quaternion.identity);
        fxHolder.transform.parent = parent;
    }
}
