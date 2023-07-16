using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;
    private bool shoulMove = false;
    public Vector3 offSet; 
    
    
    
    void Start()
    {
        transform.position = target.position + offSet;
    }
}
