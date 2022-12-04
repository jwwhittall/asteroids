using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupSpawner : MonoBehaviour
{
    public shield shieldPrefab;
    public nukePowerup nukePrefab;

    public float trajectoryVariance = 15.0f;

    public float spawnRate = 2.0f;

    public int spawnAmount = 1;

    public float spawnDistance = 15.0f;

    public GameManager gameManager;

    public nukeCollider nuke;

    public int type;

    private void Start()
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

            type = Random.Range(1, 3);
            Debug.Log(type);
            if (type == 1)
            {
                shield shield = Instantiate(this.shieldPrefab, spawnPoint, rotation);
                shield.SetTrajectory(rotation * -spawnDirection);
                shield.gameManager = this.gameManager;
            }
            else if (type == 2)
            {
                nukePowerup nukePowerup = Instantiate(this.nukePrefab, spawnPoint, rotation);
                nukePowerup.SetTrajectory(rotation * -spawnDirection);
                nukePowerup.nuCollider = this.nuke;
            }
        }
    }
}
