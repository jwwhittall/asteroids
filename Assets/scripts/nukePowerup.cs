using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nukePowerup : MonoBehaviour {

    public nukeCollider nuCollider;

    private Rigidbody2D _rigidbody;
    public float speed = 50.0f;
    public float maxLifetime = 30.0f;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            nuCollider.nuke();
        }
    }

    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifetime);
    }
}
