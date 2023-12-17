using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public AudioClip music;
    public AudioSource audiosource;
    private bool _isplaying = false;

    public static bool effectEnabled = false;


    private void Awake()
    {
        audiosource.clip = music;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (!_isplaying)
            {
                audiosource.Play();
                _isplaying = true;
            }
            else
            {
                audiosource.Pause();
                _isplaying = false;
            }

            print("pum pum");
        }
    }
}
