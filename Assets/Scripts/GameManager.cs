using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public EdgeCollider2D Walls;
    public Vector3 ScrToW;
    public movementSquare PaddleUp;
    public movementSquare PaddleDown;

    void Start()
    {
        ScrToW = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));
        List<Vector2> points = new List<Vector2> {

            new Vector2(-ScrToW.x, ScrToW.y),
            new Vector2(ScrToW.x, ScrToW.y),
            new Vector2(ScrToW.x, -ScrToW.y),
            new Vector2(-ScrToW.x, -ScrToW.y),
            new Vector2(-ScrToW.x, ScrToW.y)
        };
        Walls.SetPoints(points);
    }

    void Update()
    {
        
    }
}
