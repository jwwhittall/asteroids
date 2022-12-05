using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public bullet bulletPrefab;

    private Rigidbody2D _rigidbody;
    public bool _thrusting;

    public float thrustSpeed = 2.0f;
    public float turnSpeed = 1.0f;

    private float _turnDirection;

    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[0];
    }

    private void Update()
    {
        _thrusting = (Input.GetKey(KeyCode.W));

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * thrustSpeed, Space.World);
            //_turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * thrustSpeed, Space.World);
            //_turnDirection = -1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * thrustSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, 0.0f, turnSpeed, Space.World);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, 0.0f, -turnSpeed, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }

    private void FixedUpdate()
    {
    
        if (_thrusting)
        {
            transform.Translate(Vector3.up * Time.deltaTime * thrustSpeed, Space.World);
            // _rigidbody.AddForce(this.transform.up * this.thrustSpeed);
        }
       
        /*

        if (_turnDirection != 0.0f)
        {
            _rigidbody.AddTorque(_turnDirection * this.turnSpeed);
        }
        */

    }
    private void Shoot()
    {
        bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();

        }
    }
}


