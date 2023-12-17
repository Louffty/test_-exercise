using UnityEngine;

public class DubEchoEffect : MonoBehaviour
{
    public float delayTime = 0.3f; // ����� �������� � ��������
    public float feedback = 0.5f; // �������� ����� (�� 0 �� 1)

    private AudioSource audioSource;
    private float[] delayBuffer;
    private int bufferSize;
    private int writeIndex;
    private int readIndex;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        bufferSize = Mathf.RoundToInt(delayTime * audioSource.clip.frequency);
        delayBuffer = new float[bufferSize];
        writeIndex = 0;
        readIndex = bufferSize - 1; // �������� ��������� � ����� ������
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            // ������ �� ��������
            float delayedSample = delayBuffer[readIndex];
            // ������ � ��������
            delayBuffer[writeIndex] = data[i] + delayedSample * feedback;
            // ���������� ������� � ��������� �����
            data[i] = data[i] + delayedSample * feedback;

            writeIndex = (writeIndex + 1) % bufferSize;
            readIndex = (readIndex + 1) % bufferSize;
        }
    }
}
