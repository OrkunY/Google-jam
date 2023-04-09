using System;
using System.Collections;
using System.Collections.Generic;
using AudioManagerNM;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;


public class ObjectSpawner : MonoBehaviour
{
    
    public float spawnTimer;
    private float _spawnTimer;
    public GameObject objectToSpawn;
    public GameObject objectToSpawn2;
    
    public Transform[] spawnPoints;
    public int amountOfSpawmPoints;
    public int amountOfSpawmPoints2;
    
    private int chosenSpawnPoints;
    private int chosenSpawnPoints2;
    


    private float delay = 4f;
    
    public  int totalScore = 25;
    
    [SerializeField] TextMeshProUGUI score;
    [SerializeField]  GameObject victoryMessage;
    [SerializeField]  GameObject miniGame;
    
    AudioSource _audio;
    AudioManager _musicFiles;
    private GameObject _music;
    [SerializeField] private int Number;

    private Scene _scene;

    
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }
    
    public void Start()
    {
        _spawnTimer = spawnTimer;
        _audio = GetComponent<AudioSource>();
        score.text = totalScore.ToString();
        
        _music = GameObject.Find("AudioManager");
        _musicFiles = _music.GetComponent(typeof(AudioManager)) as AudioManager;
        
        
    }


    public void Update()
    {
        Number = Random.Range(0,23); // range i kullandiginiz music dosyasi kadar ayarlayin
        
        if (spawnTimer > 0)
            spawnTimer -= 1 * Time.deltaTime;
        
        if (spawnTimer <= 0)
            Spawn();
    }

    public void Spawn()
    {
        chosenSpawnPoints = Random.Range(0, amountOfSpawmPoints);
        chosenSpawnPoints2 = Random.Range(0, amountOfSpawmPoints2);
        

        Instantiate(objectToSpawn.transform, spawnPoints[chosenSpawnPoints].transform.position, Quaternion.identity);
        Instantiate(objectToSpawn2.transform, spawnPoints[chosenSpawnPoints2].transform.position, Quaternion.identity);
        
        spawnTimer = _spawnTimer;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Collectible"))
        {
            Destroy(col.gameObject);
            //_audio.Play();
            AudioSource.PlayClipAtPoint(_musicFiles.music[Number],gameObject.transform.position);
            totalScore--;
            score.text = totalScore.ToString();
        }

        

        if (totalScore == 0)
        {
            CancelInvoke("Spawn");
            victoryMessage.SetActive(true);
            StartCoroutine(BacktoMainMap());
            //miniGame.SetActive(false);
            

        }
        
        

        
    }
    
    IEnumerator BacktoMainMap()
    {
        
        yield return new WaitForSeconds(3);
        
        SceneManager.LoadScene(2);
    }

    
}