using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Camera cam;
    public Trajectory trajectory;
    public Ball ball;
    [SerializeField] private float pushForce = 4f;
    private bool isDragging = false; 

    public static GameManager Instance;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 direction;
    private Vector2 force;
    private float distance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        cam = Camera.main;
        ball.DesativateRb();
    }

   
    void Update()
    {
        if (ball.IsLaunched)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) && PauseMenu.instance.CanInput)
        {
            isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            OnDragEnd();
        }

        if (isDragging)
        {
            OnDrag();
        }
    }

    void OnDragStart()
    {
        
        ball.DesativateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }
    void OnDrag()
    {
        
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;
        Debug.DrawLine(startPoint , endPoint);
        
        trajectory.UpdateDots(ball.HumanPose, force);
    }
    void OnDragEnd()
    {
        

        ball.ActivateRb();

        
       
            
        ball.Push(force);
            
       

        trajectory.Hide();
    }
}
