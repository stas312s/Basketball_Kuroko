using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BasketGoal : MonoBehaviour
{
    public int temp = 0;
    public string goalColliderTag = "FinishTrigger"; // 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Перевіряємо, чи коллайдер має потрібний тег або ідентифікатор
        if (collision.CompareTag(goalColliderTag))
        {
            StartCoroutine(WinRestart());

        }
    }
    
    void Update()
    {
        
        
    }
    
    
    
    
    private IEnumerator WinRestart()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
