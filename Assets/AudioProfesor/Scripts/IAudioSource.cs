using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class IAudioSource : MonoBehaviour
{
    private AudioSource source;
    private void Start() => source = GetComponent<AudioSource>();
    public void Play() => source.Play();
}
