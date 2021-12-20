using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterWallBehav : MonoBehaviour
{
    public GameManager gm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            CircleCollider2D col = collision.gameObject.GetComponent<CircleCollider2D>();

            if(collision.transform.position.y < (gm.ScrToW.y - col.radius) && collision.transform.position.y > (-gm.ScrToW.y + col.radius))
            {
                Rigidbody2D ba = collision.GetComponent<Rigidbody2D>();
                ba.velocity = new Vector2(ba.velocity.x * -1, ba.velocity.y);
            }
        }
    }
}
