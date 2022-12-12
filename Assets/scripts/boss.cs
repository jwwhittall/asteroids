using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public int hp = 20;

    public bossAsteroidSpawner spawner;

    public GameManager gameManager;

    public BoxCollider2D bCollider;

    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.bCollider = GetComponent<BoxCollider2D>();
        bCollider.enabled = false;
        spriteRenderer.enabled = false;
    }

    public void bossStart()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.bCollider = GetComponent<BoxCollider2D>();
        spriteRenderer.enabled = true;
        bCollider.enabled = true;
        this.Attack();
    }

    public void Attack()
    {
        spawner.spawnRate = 0.1f;
        spawner.startAttack();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            hp = hp - 1;
            Debug.Log(hp);
            if (hp <= 0)
            {
                gameManager.win();
                Destroy(this.gameObject);
            }
        }
    }
}
