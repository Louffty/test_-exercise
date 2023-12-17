using UnityEngine;

public class DubEchoEffect : MonoBehaviour
{
    public float delayTime = 0.3f; // Время задержки в секундах
    public float feedback = 0.5f; // Обратная связь (от 0 до 1)

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
        readIndex = bufferSize - 1; // Начинаем считывать с конца буфера
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            // Чтение из задержки
            float delayedSample = delayBuffer[readIndex];
            // Запись в задержку
            delayBuffer[writeIndex] = data[i] + delayedSample * feedback;
            // Применение эффекта к исходному звуку
            data[i] = data[i] + delayedSample * feedback;

            writeIndex = (writeIndex + 1) % bufferSize;
            readIndex = (readIndex + 1) % bufferSize;
        }
    }
}
