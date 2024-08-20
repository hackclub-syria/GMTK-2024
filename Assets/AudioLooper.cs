/*using UnityEngine;

public class AudioLoopers : MonoBehaviour
{
    public AudioSource audioSource;  // The audio source component
    private float currentSpeed = 1f; // The current playback speed

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        audioSource.loop = true;  // Ensure the audio is looping
        audioSource.pitch = currentSpeed;
    }

    void Update()
    {
        // Simulate calling the function every second
        if (Time.frameCount % 60 == 0) // Assuming 60 FPS
        {
            float speed = Random.Range(0.5f, 2f);  // Example: change this to your desired speed
            SetPlaybackSpeed(speed);
        }
    }

    // Function to set the playback speed
    public void SetPlaybackSpeed(float speed)
    {
        // If speed changes, update the audio source pitch
        if (currentSpeed != speed)
        {
            currentSpeed = speed;
            audioSource.pitch = currentSpeed;
            audioSource.time %= audioSource.clip.length / currentSpeed; // Adjust the position to avoid skipping
        }
    }
}
*/