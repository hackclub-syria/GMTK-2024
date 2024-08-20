using UnityEngine;

public class AudioLooper : MonoBehaviour
{
    public AudioSource audioSource;
    private float interval = 1.0f;
    private float previousValue = -1f;

    public void PlayAudio(float newValue)
    {
        if (HasWholeNumberChanged(previousValue, newValue))
        {
            audioSource.Stop();
            if (newValue <= 0)
            {
                CancelInvoke("LoopAudio");
                return;
            }
            audioSource.pitch = Mathf.Lerp(0.1f, 2.0f, newValue / 11f);

            audioSource.Play();

            interval = Mathf.Lerp(5f, 0.1f, newValue / 11f);

            InvokeRepeating("LoopAudio", 0f, interval);
        }

        previousValue = newValue;
    }

    private bool HasWholeNumberChanged(float oldValue, float newValue)
    {
        return Mathf.FloorToInt(oldValue) != Mathf.FloorToInt(newValue);
    }

    private void LoopAudio()
    {
        audioSource.Play();
    }

    public void StopAudio()
    {
        CancelInvoke("LoopAudio");
        audioSource.Stop();
    }
}
