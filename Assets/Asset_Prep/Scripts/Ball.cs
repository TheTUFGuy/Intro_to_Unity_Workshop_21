using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballVel = 4;
    public GameManager gm;
    Vector2 dir ;
    Rigidbody2D rb;

    private void Awake()
    {
        dir = Random.insideUnitCircle;
    }

    void Start()
    {
        resurrect(dir, gm);
    }


    void Update()
    {
        if(transform.position.y > gm.ScrToW.y || transform.position.y < -gm.ScrToW.y)
        {
            Destroy(gameObject);
        }
    }

    public void resurrect(Vector2 dir, GameManager gm)
    {
        this.dir = dir;
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = dir.normalized * ballVel;
        this.gm = gm;
    }
}
