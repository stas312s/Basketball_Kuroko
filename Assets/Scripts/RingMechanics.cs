using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingMechanics : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D ballRigidbody;
    private bool ballEntered;

    private void Start()
    {
        ballRigidbody = null;
        ballEntered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") && !ballEntered)
        {
            ballEntered = true;
            ballRigidbody = collision.GetComponent<Rigidbody2D>();
            ballRigidbody.velocity = Vector2.zero;
            ballRigidbody.angularVelocity = 0f;
            ballRigidbody.isKinematic = true;
            collision.transform.position = player.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") && ballEntered)
        {
            ballEntered = false;
            ballRigidbody.isKinematic = false;
        }
    }
}
