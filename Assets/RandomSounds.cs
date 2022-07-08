using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> audioList;
    public float time;
    public bool playSound;
    bool changeSound;

    public AudioClip GetRandomSound(List<AudioClip> soundToRandomize)
    {
        int randomNum = Random.Range(0, audioList.Count);
        //Sprite newSprite = spritesToRandomize[randomNum];
        AudioClip newSound = soundToRandomize[randomNum];
        return newSound;
    }

    public void ChangeSound()
    {

        if (!changeSound)
            return;

        Debug.Log("changeSound");
        source.clip = GetRandomSound(audioList);
        source.Play();
        changeSound = false;
        time = 5;
        playSound = true;
    }
    private void Awake()
    {
        playSound = true;
        changeSound = true;
        ChangeSound();
    }
    void Update()
    {
        if (playSound == true)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            playSound = false;
            changeSound = true;
            ChangeSound();
        }



    }
}
