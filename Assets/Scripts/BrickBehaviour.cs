using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    public GameManager gm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            RaycastHit2D hit = Physics2D.Raycast(collision.transform.position, collision.gameObject.GetComponent<Rigidbody2D>().velocity);

            if (hit.point.y - transform.position.y < GetComponent<BoxCollider2D>().size.y *transform.localScale.y/ 2)
            {
                Vector2 vel = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(vel.x * -1, vel.y);
            }
            if (hit.point.x - transform.position.x < GetComponent<BoxCollider2D>().size.x * transform.localScale.x/ 2)
            {
                Vector2 vel = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(vel.x, vel.y* -1);
            }

            Destroy(gameObject);
        }
    }
}
