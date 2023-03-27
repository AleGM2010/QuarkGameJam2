using UnityEngine;

public class Ball_Sound : MonoBehaviour {
    public AudioClip audioClip;
    private AudioSource audioSource;


    private void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    public void PlaySound() {
        audioSource.PlayOneShot(audioClip);
    }
}
