using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public float maxLifetime = 5.0f;

    public float speed = 500.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "boundary")
        {
            Destroy(this.gameObject);
        }
    }
}



