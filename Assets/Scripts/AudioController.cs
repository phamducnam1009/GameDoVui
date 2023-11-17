using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public static AudioController instance;
    [Range(0, 1)]
    public float musicVolume;
    [Range(0, 1)]
    public float soundVolume;
    public AudioSource music;
    public AudioSource soundAus;
    public AudioClip[] backgroundMusic;
    public AudioClip rightSound;
    public AudioClip loseSound;
    public AudioClip winSound;
    private void Awake()
    {
        MakeSingleton();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayBackgroundMusic();
    }
    private void Update()
    {
        music.volume= musicVolume;
        soundAus.volume= soundVolume;
    }
    public void PlayBackgroundMusic()
    {
        if (music && backgroundMusic!= null && backgroundMusic.Length>0)
        {
            int randomInx = Random.Range(0, backgroundMusic.Length);
            if (backgroundMusic[randomInx])
            {
                music.clip = backgroundMusic[randomInx];
                music.volume = musicVolume;
                music.Play();
            }
        }
    }
    public void PlaySound(AudioClip sound)
    {
        if (soundAus && sound)
        {
            soundAus.volume = soundVolume;
            soundAus.PlayOneShot(sound);
        }
    }
    public void PlayRightSound()
    {
        PlaySound(rightSound);
    }
    public void PlayLoseSound()
    {
        PlaySound(loseSound);
    }
    public void PlayWinSound()
    {
        PlaySound(winSound);

    }
   public void StopMusic()
    {
        if (music)
        {
            music.Stop();
        }
    }
   
    public void MakeSingleton()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
      
    }
}
