using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using  UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public float spawnTimer;
    private float _spawnTimer;
    
    public GameObject bullet;
    public Transform[] spawnPoints;
    public int amountOfSpawmPoints;
    private int chosenSpawnPoints;
    
    public int lives = 3;
    [SerializeField] TextMeshProUGUI livesCount;
    
    AudioSource _audio;

    private Scene _scene;
    
    
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }
    
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _spawnTimer = spawnTimer;
    }

    private void Update()
    {
        if (spawnTimer > 0)
            spawnTimer -= 1 * Time.deltaTime;
        
        if (spawnTimer <= 0)
            Spawn();
    }

    public void Spawn()
    {
        chosenSpawnPoints = Random.Range(0, amountOfSpawmPoints);
        
        Instantiate(bullet.transform, spawnPoints[chosenSpawnPoints].transform.position, Quaternion.identity);

        spawnTimer = _spawnTimer;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            lives--;
            _audio.Play();
            livesCount.text = lives.ToString();
        }
        if (lives == 0)
            RestartLevel();
        
        
        
    }
    void RestartLevel() 
    {
        SceneManager.LoadScene(2); 
    }

    
}