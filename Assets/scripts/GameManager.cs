using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public player player;

    public ParticleSystem explosion;

    public Text scoreText;
    public Text livesText;

    public restart restartButton;
    public winContinue continueButton;

    public int lives = 3;

    public float respawnTime = 3.0f;

    public float speed = 5.0f;

    public float respawnInvulnerabilityTime = 3.0f;

    public float shieldTime = 5.0f;

    public int score = 0;

    public bool bossSpawned;

    public asteroidSpawner asteroidSpawner;
    public powerupSpawner powerupSpawner;

    public boss bossPrefab;

    public confetti confettiPrefab;

    public void Start()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            this.score = PlayerPrefs.GetInt("score");
            this.bossSpawned = true;
        }
        else bossSpawned = false;
    }

    public void AsteroidDestroyed(asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        if (asteroid.size < 0.75f)
        {
            this.score += 100;
        }
        else if (asteroid.size < 1.2f)
        {
            this.score += 50;
        }
        else
        {
            this.score += 25;
        }

        if (this.score >= 3000 && bossSpawned == false)
        {
            asteroidSpawner.spawnAmount = 0;
            powerupSpawner.spawnAmount = 0;
            bossSpawned = true;
            StartCoroutine(boss());
        }
    }

    IEnumerator boss()
    {
        yield return new WaitForSeconds(5);
        bossPrefab.bossStart();
    }

    public void PlayerDied()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        this.lives--;

        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        { 
            Invoke(nameof(Respawn), this.respawnTime);
        }

    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("ignore collisions");
        this.player.spriteRenderer.sprite = this.player.spriteArray[1];
        this.player.gameObject.SetActive(true);
        this.Invoke(nameof(TurnOnCollisions), this.respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.spriteRenderer.sprite = this.player.spriteArray[0];
        this.player.gameObject.layer = LayerMask.NameToLayer("player");
    }

    public void Shield()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("ignore collisions");
        this.player.spriteRenderer.sprite = this.player.spriteArray[1];
        this.Invoke(nameof(TurnOnCollisions), this.shieldTime);
    }

    private void GameOver()
    {
        this.restartButton.spriteRenderer.enabled = true;
        this.restartButton.rCollider.enabled = true;
    }


    private void Update()
    {
        this.scoreText.text = this.score.ToString();
        this.livesText.text = this.lives.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.K))
        {
            score = 3000;
        }
    }

    public void win()
    {
        Instantiate(this.confettiPrefab);
        this.player.gameObject.layer = LayerMask.NameToLayer("ignore collisions");
        PlayerPrefs.SetInt("score", this.score);
        this.restartButton.spriteRenderer.enabled = true;
        this.restartButton.rCollider.enabled = true;
        this.continueButton.spriteRenderer.enabled = true;
        this.continueButton.rCollider.enabled = true;
        this.restartButton.spriteRenderer.sprite = this.restartButton.spriteArray[1];
    }

}


