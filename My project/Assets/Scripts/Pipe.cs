using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float maxTime = 1;
    public float timer = 0;
    public GameObject Engel;
    public float yukseklik;
    void Start()
    {
        GameObject newEngel = Instantiate(Engel); 
        newEngel.transform.position = transform.position + new Vector3(0, Random.Range(-yukseklik,yukseklik),0);
    }

    void Update()
    {
        if(timer > maxTime)
        {
            GameObject newEngel = Instantiate(Engel); 
        newEngel.transform.position = transform.position + new Vector3(0, Random.Range(-yukseklik,yukseklik),0);
        Destroy(newEngel,15 );
        timer = 0;
        }
        timer += Time.deltaTime;
    }
}
