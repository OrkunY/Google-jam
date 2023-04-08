using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    public float ziplama_araligi;
    Rigidbody2D r2d;
    public int scor = 0;
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            r2d.velocity = Vector2.up * ziplama_araligi;
        }
        
    }
    void OnTriggerEnter2D(Collider2D temas)
    {
        if(temas.gameObject.tag == "scorer")
        {
            scor++;
        }
        if(scor >= 10){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
    void OnCollisionEnter2D(Collision2D temas)
    {
        if(temas.gameObject.tag == "engel"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
