using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class IAudioManager : MonoBehaviour
{
    [SerializeField] private IAudioSource[] sources;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
            Play();
        if (Input.GetKeyDown(KeyCode.Alpha1))
            sources[0].Play();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            sources[1].Play();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            sources[2].Play();
    }

    private AudioSource source;
    private void Start() => source = GetComponent<AudioSource>();
    public void Play() => source.Play();
}
