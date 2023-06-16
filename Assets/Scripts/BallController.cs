using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector2 startMousePos;
    private Vector2 endMousePos;
    private Rigidbody2D rb;
    public float forceMultiplier = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endMousePos = Input.mousePosition;
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        Vector2 swipeDirection = (endMousePos - startMousePos).normalized;
        Vector2 force = -swipeDirection * forceMultiplier;
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
