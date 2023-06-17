using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform startPoint;
    public Transform endPoint;
    public float maxDistance = 5f;
    public float aimMultiplier = 1.5f;

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 aimDirection = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        aimDirection.z = 0f;

        // Нормалізуємо напрямок тяги
        aimDirection.Normalize();

        // Множимо напрямок на множник, щоб змінити напрямок прицілу
        Vector3 aimVector = aimDirection * -aimMultiplier;

        // Обчислюємо позицію кінцевої точки прицілу
        Vector3 targetPosition = transform.position + aimVector;

        // Обмежуємо відстань прицілу, якщо вона більше maxDistance
        Vector3 clampedPosition = transform.position + Vector3.ClampMagnitude(aimVector, maxDistance);

        // Оновлюємо позицію початкової та кінцевої точок
        startPoint.position = transform.position;
        endPoint.position = clampedPosition;

        // Оновлюємо лінію у LineRenderer
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);
    }

}