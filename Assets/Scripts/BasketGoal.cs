using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BasketGoal : MonoBehaviour
{
    public string goalColliderTag = "FinishTrigger"; // 
    public static bool isWin;
    public AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag(goalColliderTag))
        {
            StartCoroutine(WinRestart());
            audioSource.Play();
        }
    }
    
    private IEnumerator WinRestart()
    {
        yield return new WaitForSeconds(0.7f);
        isWin = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
