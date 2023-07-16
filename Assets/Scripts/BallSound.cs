using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    [SerializeField]private AudioSource audioSource;
    [SerializeField]private AudioSource shieldSource;
    [SerializeField] private AudioSource ringSource;
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            audioSource.Play();
        }
        if (collision.gameObject.CompareTag("Shield"))
        {
            shieldSource.Play();
        }

        if (collision.gameObject.CompareTag("FinishTrigger"))
        {
            ringSource.Play();
        }
    }
}
