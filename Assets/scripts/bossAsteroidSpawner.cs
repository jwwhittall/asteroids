using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAsteroidSpawner : MonoBehaviour
{
    public bossAsteroid bossAsteroidPrefab;

    public float trajectoryVariance = 1.0f;

    public float spawnRate = 0.1f;

    public int spawnAmount = 1;

    public float spawnDistance = 1.0f;

    public GameManager gameManager;

    public void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            startAttack();
        }
    }

    public void startAttack()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {

            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            bossAsteroid bossAsteroid = Instantiate(this.bossAsteroidPrefab, spawnPoint, rotation);
            bossAsteroid.gameManager = this.gameManager;
            bossAsteroid.size = Random.Range(bossAsteroid.minSize, bossAsteroid.maxSize);
            bossAsteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
