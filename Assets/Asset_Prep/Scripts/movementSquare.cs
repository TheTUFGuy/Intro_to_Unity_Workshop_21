using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementSquare : MonoBehaviour
{
    [Header("Public Variables")]
    public float runSpeed = 10.0f;
    public float friction;
    public GameManager gameManager;
    public GameObject Ball;
    bool isOr = false;
    public bool isUp = false;

    float x;
    private float vel;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(isUp)
            x = Input.GetAxisRaw("Horizontal");
        else
            x = Input.GetAxisRaw("Horizontal2");
    }

    private void FixedUpdate()
    {
        if(x == 0)
            body.velocity *= friction;
        else
            body.velocity = new Vector2(runSpeed * x, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isUp)
        {
            if (collision.tag == "Ball" && !isOr)
            {
                if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
                {
                    collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                }

                GameObject ball = Instantiate(Ball);
                float dist = collision.transform.position.x - transform.position.x;
                gameManager.PaddleDown.isOr = true;
                ball.GetComponent<Ball>().resurrect(collision.GetComponent<Rigidbody2D>().velocity, gameManager);
                ball.transform.position = new Vector3(gameManager.PaddleDown.transform.position.x + dist, gameManager.PaddleDown.transform.position.y, gameManager.PaddleDown.transform.position.z);
            }
        }
        else
        {
            if (collision.tag == "Ball" && !isOr)
            {
                if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
                {
                    collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                }

                GameObject ball = Instantiate(Ball);
                float dist = collision.transform.position.x - transform.position.x;
                gameManager.PaddleUp.isOr = true;
                ball.GetComponent<Ball>().resurrect(collision.GetComponent<Rigidbody2D>().velocity, gameManager);
                ball.transform.position = new Vector3(gameManager.PaddleUp.transform.position.x + dist, gameManager.PaddleUp.transform.position.y, gameManager.PaddleUp.transform.position.z);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            this.isOr = false;
        }
    }
}