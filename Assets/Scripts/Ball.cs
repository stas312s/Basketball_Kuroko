using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    public float rangeX = 10f;
    public float rangeY = 0f;
    public Vector3 initialPosition;
    private Vector3 savedLocation;
    private string savePath = "save.json";
    public string groundTag = "Ground";  // Тэг объекта земли
    public float restartDelay = 2f;  // Задержка перед перезапуском сцены
    private bool hasCollided = false;
    
    public bool IsLaunched { get; private set; } = false;

    public Score score;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;

    [HideInInspector] public Vector3 HumanPose
    {
        get { return transform.position; }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        initialPosition = transform.position;
        transform.position = LoadTransform();
        if (BasketGoal.isWin)
        {
            TransformBall();
            BasketGoal.isWin = false;
        }
    }
    
    public void SaveTransform(Transform transformToSave)
    {
        Vector3Serializable vector3Serializable = new Vector3Serializable();
        vector3Serializable.X = transformToSave.position.x;
        vector3Serializable.Y = transformToSave.position.y;
        vector3Serializable.Z = transformToSave.position.z;
        string json = JsonUtility.ToJson(vector3Serializable);
        PlayerPrefs.SetString(savePath, json);
    }

    public Vector3 LoadTransform()
    {
        if (!PlayerPrefs.HasKey(savePath))
        {
            return transform.position;
        }
        var json = PlayerPrefs.GetString(savePath);
        Vector3Serializable vector3Serializable = JsonUtility.FromJson<Vector3Serializable>(json);
        return new Vector3(vector3Serializable.X, vector3Serializable.Y, vector3Serializable.Z);
    }
    
    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
        StartCoroutine(Restart());
       
        IsLaunched = true;
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag(groundTag) && !hasCollided)
        {
            hasCollided = true;
            StartCoroutine(RestartScene());
        }
    }

    private System.Collections.IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(restartDelay);
        LooseGame();
    }
    
    public void ActivateRb()
    {
        rb.isKinematic = false;
    }
    
    public void DesativateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }
    
    public void TransformBall()
    {
        float randomX = Random.Range(initialPosition.x - rangeX, initialPosition.x + rangeX);
        float randomY = Random.Range(initialPosition.y - rangeY, initialPosition.y + rangeY);
        Vector3 newPosition = new Vector3(randomX, randomY, transform.position.z);
        transform.position = newPosition;
        SaveTransform(transform);
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(15.0f);
        LooseGame();
    }

    private void LooseGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Zero();
    }

    public void Zero()
    {
        PlayerPrefs.SetInt("Score", Score.instance.score = 0);
    }
}

