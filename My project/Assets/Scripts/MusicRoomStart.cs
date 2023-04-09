using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicRoomStart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene(6);
    }
}
