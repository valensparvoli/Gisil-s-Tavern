using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle1 : MonoBehaviour
{
    public AudioSource source;
    public string bottleName;
    private Vector3 basePosition;
    private Quaternion baseRotation;
    public PickUpObject pickObject;
    public Material bottleMat;
    public AudioClip botellaDestapandose;
    public AudioClip ruidoBotella;

    private void Awake()
    {
        basePosition = transform.position;
        baseRotation = transform.rotation;
    }
    public void RestartPosition()
    {
        //transform.SetPositionAndRotation(basePosition, baseRotation);
        //audioCp = audioList[1];
        source.clip = ruidoBotella;
        source.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Glass"))
        {
            source.clip = botellaDestapandose;
            source.Play();
        }
    }
    public void PlayBottleSound()
    {
        //audioCp = audioList[2];
        source.clip = botellaDestapandose;
        source.Play();
    }
}
