using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketWinTrigger : MonoBehaviour
{
    // Тег, який ви хочете присвоїти обраному колайдеру
    public string desiredTag = "FinishTrigger";

    // Індекс обраного колайдера
    public int selectedColliderIndex = 2;

    private void Start()
    {
        // Отримуємо всі колайдери об'єкту
        Collider[] colliders = GetComponentsInChildren<Collider>();
        
        foreach (Collider collider in colliders)
        {
            string colliderName = collider.name;
            Debug.Log("Collider name: " + colliderName);
        }

        // Перевіряємо, чи індекс обраного колайдера не перевищує довжину масиву колайдерів
        if (selectedColliderIndex >= 0 && selectedColliderIndex < colliders.Length)
        {
            // Присвоюємо обраному колайдеру бажаний тег
            colliders[selectedColliderIndex].tag = desiredTag;
            Debug.Log("Work");
        }
    }

    private void Update()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        
        foreach (Collider collider in colliders)
        {
            string colliderName = collider.name;
            Debug.Log("Collider name: " + colliderName);
        }
    }
}
