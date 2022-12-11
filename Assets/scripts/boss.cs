using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public int hp = 500;

    public bossAsteroidSpawner spawner;

    public GameManager gameManager;

    public BoxCollider2D bCollider;

    public void Awake()
    {
        this.bCollider = GetComponent<BoxCollider2D>();
        bCollider.enabled = false;
    }

    public void bossStart()
    {
        this.transform.Translate(Vector3.down * 3.0f, Space.World);
        //cowboy hat animation
        this.Attack();
    }

    public void Attack()
    {
        spawner.spawnRate = 5.0f;
    }
}
