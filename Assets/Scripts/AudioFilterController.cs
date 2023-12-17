using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioFilterController : MonoBehaviour
{
    public AudioMixerGroup mixerGroup; // ��������� ������, � ������� ����� ����������� ������

    [Range(1, 16)]
    public int bitDepth = 8; // ������� ���� (Bit Depth)

    private AudioLowPassFilter lowPassFilter;
    private int lastBitDepth = 8; // �������� ������� ���� �� ���������� �����

    void Start()
    {
        lowPassFilter = gameObject.AddComponent<AudioLowPassFilter>();
        lowPassFilter.cutoffFrequency = 22000; // ��������� ��������� ������� �����
    }

    void Update()
    {
        if (bitDepth != lastBitDepth)
        {
            // ��������� ������� ����� �� ������ ������� ���� (����� ��������� �� ������ ����������)
            float cutoffFrequency = Mathf.Lerp(22000, 100, (bitDepth - 1) / 15f);
            lowPassFilter.cutoffFrequency = cutoffFrequency;
            lastBitDepth = bitDepth;
        }
    }
}