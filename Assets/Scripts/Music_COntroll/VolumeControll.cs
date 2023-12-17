using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControll : MonoBehaviour
{
    public GameObject volumeSlider;
    public GameObject helpText;
    public AudioSource audioSource;

    private bool isChanging = false;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseLook.canMoving = false;
            volumeSlider.SetActive(true);
            helpText.SetActive(true);
        }
    }

    private void Update()
    {
        audioSource.volume = volumeSlider.GetComponent<Slider>().value;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mouseLook.canMoving = true;
            volumeSlider.SetActive(false);
            helpText.SetActive(false);
        }
    }
}
