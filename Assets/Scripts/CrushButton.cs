using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushButton : MonoBehaviour
{

    public AudioSource targetAudioSource; // Публичная переменная для AudioSource

    [Range(1, 16)]
    public int bitDepth = 8;
    [Range(0.01f, 1f)]
    public float sampleRateReduction = 0.5f;

    private bool effectEnabled = false; // Флаг активации эффекта



    void OnAudioFilterRead(float[] data, int channels)
    {
        

        for (int i = 0; i < data.Length; i++)
        {
            // Применяем битовую глубину
            float quantizedSample = QuantizeSample(data[i], bitDepth);
            data[i] = quantizedSample;

            // Снижаем частоту дискретизации
            if (sampleRateReduction < 1)
            {
                if (i % channels == 0)
                {
                    for (int j = 1; j < channels; j++)
                    {
                        data[i + j] = data[i];
                    }
                }
            }
        }
    }

    float QuantizeSample(float sample, float bitDepth)
    {
        float maxSample = Mathf.Pow(2, bitDepth) / 2 - 1;
        return Mathf.Round(sample * maxSample) / maxSample;
    }


    /*
    void OnAudioFilterRead(float[] data, int channels)
    {
        if (!effectEnabled) return; // Если эффект не активен, не делаем ничего

        int downsamplingRate = Mathf.Max(1, (int)(data.Length * downsampleFactor / data.Length));

        for (int i = 0; i < data.Length; i += channels)
        {
            float quantizedSample = QuantizeSample(data[i], bitDepth);
            for (int c = 0; c < channels; c++)
            {
                data[i + c] = quantizedSample;
            }
        }
    }

    float QuantizeSample(float sample, int bits)
    {
        int levels = (1 << bits) - 1;
        return Mathf.Round(sample * levels) / levels;
    }
    */


    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (effectEnabled)
            {
                effectEnabled = false;
            }
            else
            {
                print("asdasd");

                effectEnabled = true;
            }
        }
    }

    
}
