using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed = 5;
    public Vector2 vel;
    public bool gameStarted;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
       
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && gameStarted = false)
            SendBallToRandomDirection();
    }
    private void SendBallToRandomDirection()
    {
        rb2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        rb2D.velocity = GenerateRandomVector2Without0(true) * speed;
        vel = rb2D.velocity;
    }

    private Vector2 GenerateRandomVector2Without0(bool shouldReturnNormalized)
    {
        Vector2 newVelocity = new Vector2();
        bool shouldGoRight = Random.Range(1, 100) > 50;
        newVelocity.x = shouldGoRight ? Random.Range(0f, 2f) : Random.Range(0f, - 2f);
        newVelocity.y = shouldGoRight ? Random.Range(-1f, 1f) : Random.Range(0f, -2f);

        if (shouldReturnNormalized)
        {
           return newVelocity.normalized;
        }

        return newVelocity;
    }


    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        rb2D.velocity = Vector2.Reflect(vel, collision.contacts[0].normal);
        vel = rb2D.velocity;
        

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x < 0f)
            print("Left player +1");
        if (transform.position.y > 0f)
            print("Right player +1");

        rb2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        gameStarted = false;
       
       
    }
}



