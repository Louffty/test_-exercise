using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Crush_Button : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioMixerGroup mixergroup;
    public AudioMixerGroup maingroup;
    

    private bool _isPressed = false;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isPressed) 
            {
                audiosource.outputAudioMixerGroup = mixergroup;
                _isPressed = true;
            }
            else
            {
                audiosource.outputAudioMixerGroup = maingroup;
                _isPressed = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (audiosource.outputAudioMixerGroup != mixergroup)
        {
            GetComponent<Outline>().enabled = false;
        }

        else 
        {
            GetComponent<Outline>().enabled = true;
        }
    }
}
