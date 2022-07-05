using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle1 : MonoBehaviour
{
    /*
    public BottleSO typeBottle;
    public Transform posOriginal;
    */
    public AudioSource source;
    public string bottleName;

    private Vector3 basePosition;
    private Quaternion baseRotation;
    public PickUpObject pickObject;
    //public List<AudioClip> audioList;
    //AudioClip audioCp;
    public Material bottleMat;
    public AudioClip botellaDestapandose;
    public AudioClip ruidoBotella;

    //public ParticleSystem myParticleSistem;

    private void Awake()
    {
        basePosition = transform.position;
        baseRotation = transform.rotation;
        //myParticleSistem = GetComponent<ParticleSystem>();
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Glass"))
        {
            pickObject.DropObject();
            RestartPosition();
        }
    }
    */
    /*
    private void Update()
    {
        if (Vector3.Angle(Vector3.down, transform.forward) <= 90f)
        {
            myParticleSistem.Play();

        }else
        {
            myParticleSistem.Stop();
        }
    }
    */

    public void RestartPosition()
    {
        transform.SetPositionAndRotation(basePosition, baseRotation);
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
