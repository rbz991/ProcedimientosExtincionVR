using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject as this script
        audioSource = GetComponent<AudioSource>();
    }

    // Call this function to play the sound
    public void TriggerSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No AudioSource found on the GameObject.");
        }
    }
}