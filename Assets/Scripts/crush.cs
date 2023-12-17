using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crush : MonoBehaviour
{

    [Range(1, 16)]
    public int bitDepth = 8;
    [Range(0.01f, 1f)]
    public float sampleRateReduction = 0.5f;
    [Range (0f, 1f)]
    public float distortionAmount = 0.5f;


    void OnAudioFilterRead(float[] data, int channels)
    {
        if (bitDepth < 1) bitDepth = 1; // Минимальная битовая глубина

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

            // Применяем искажение
            data[i] *= (1 + distortionAmount * Mathf.Sign(data[i]));
        }
    }

    float QuantizeSample(float sample, float bitDepth)
    {
        float maxSample = Mathf.Pow(2, bitDepth) / 2 - 1;
        return Mathf.Round(sample * maxSample) / maxSample;
    }
}
