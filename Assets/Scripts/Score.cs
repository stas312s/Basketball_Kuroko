using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    public int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    public static Score instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FinishTrigger")
        {
            PlayerPrefs.SetInt("score", score);
            score++;
        }
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
    }
    
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Score", score);
       
    }

    


    void Update()
    {
        
        scoreText.text = score.ToString();
        
    }
}
