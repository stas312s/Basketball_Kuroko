using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    [SerializeField] private AudioSource _groundSource;
    [SerializeField] private AudioSource _shieldSource;
    [SerializeField] private AudioSource _goalSource;
    [SerializeField] private AudioSource _ringSource;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _groundSource.Play();
        }
        if (collision.gameObject.CompareTag("Shield"))
        {
            _shieldSource.Play();
        }

        if (collision.gameObject.CompareTag("Ring"))
        {
            _ringSource.Play();
        }

        if (collision.gameObject.CompareTag("FinishTrigger"))
        {
            _goalSource.Play();
        }
    }
}
