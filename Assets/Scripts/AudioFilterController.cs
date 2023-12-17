using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioFilterController : MonoBehaviour
{
    public AudioMixerGroup mixerGroup; // Микшерная группа, в которой будет применяться эффект

    [Range(1, 16)]
    public int bitDepth = 8; // Глубина бита (Bit Depth)

    private AudioLowPassFilter lowPassFilter;
    private int lastBitDepth = 8; // Значение глубины бита на предыдущем кадре

    void Start()
    {
        lowPassFilter = gameObject.AddComponent<AudioLowPassFilter>();
        lowPassFilter.cutoffFrequency = 22000; // Начальная настройка частоты среза
    }

    void Update()
    {
        if (bitDepth != lastBitDepth)
        {
            // Вычислить частоту среза на основе глубины бита (можно настроить по своему усмотрению)
            float cutoffFrequency = Mathf.Lerp(22000, 100, (bitDepth - 1) / 15f);
            lowPassFilter.cutoffFrequency = cutoffFrequency;
            lastBitDepth = bitDepth;
        }
    }
}