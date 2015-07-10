using UnityEngine;
using System.Collections;

public class ProjectileSound : MonoBehaviour {

    AudioSource audioSfx;
    public AudioClip initSound;
    public AudioClip hitSound;

    void Start()
    {
        audioSfx = GetComponent<AudioSource>();
        audioSfx.clip = initSound;
        audioSfx.Play();
    }

    public void hitTargetSound()
    {
        audioSfx.clip = hitSound;
        audioSfx.Play();
    }
}