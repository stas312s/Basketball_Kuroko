using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BasketGoal : MonoBehaviour
{
    public string goalColliderTag = "FinishTrigger"; // 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Перевіряємо, чи коллайдер має потрібний тег або ідентифікатор
        if (collision.CompareTag(goalColliderTag))
        {
            
            RestartScene();
        }
    }

    private void RestartScene()
    {
        
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Завантажуємо поточну сцену знову
        SceneManager.LoadScene(currentSceneName);
    }
}
