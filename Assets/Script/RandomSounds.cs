using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> audioList;
    public float time;
    [SerializeField] private int finalTime;
    public bool playSound;
    bool changeSound;

    public AudioClip GetRandomSound(List<AudioClip> soundToRandomize)
    {
        int randomNum = Random.Range(0, audioList.Count);
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
        time =finalTime;
        playSound = true;
    }
    private void Awake()
    {
        time = finalTime;
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
