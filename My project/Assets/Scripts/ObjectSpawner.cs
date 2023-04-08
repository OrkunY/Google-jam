using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class ObjectSpawner : MonoBehaviour
{
    
    public float spawnTimer;
    private float _spawnTimer;
    public GameObject objectToSpawn;
    public Transform[] spawnPoints;
    public int amountOfSpawmPoints;
    private int chosenSpawnPoints;

    private float delay = 4f;
    
    public  int totalScore = 25;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField]  GameObject victoryMessage;
    [SerializeField]  GameObject miniGame;
    
    AudioSource _audio;

    public void Start()
    {
        _spawnTimer = spawnTimer;
        _audio = GetComponent<AudioSource>();
        score.text = totalScore.ToString();
    }


    public void Update()
    {
        if (spawnTimer > 0)
            spawnTimer -= 1 * Time.deltaTime;
        
        if (spawnTimer <= 0)
            Spawn();
    }

    public void Spawn()
    {
        chosenSpawnPoints = Random.Range(0, amountOfSpawmPoints);
        Instantiate(objectToSpawn.transform, spawnPoints[chosenSpawnPoints].transform.position, Quaternion.identity);
        spawnTimer = _spawnTimer;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Collectible"))
        {
            Destroy(col.gameObject);
            //_audio.Play();
            totalScore--;
            score.text = totalScore.ToString();
        }

        if (totalScore == 0)
        {
            victoryMessage.SetActive(true);
            miniGame.SetActive(false);
        }
    }
}

