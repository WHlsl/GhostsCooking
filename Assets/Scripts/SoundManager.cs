using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance;
    private AudioSource audioSource;
    
    public AudioClip[] soundEffects;
	// Use this for initialization
	void Start () {
        Instance = this;
        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlaySoundAtPosition(string name,Vector3 position)
    {
        foreach(AudioClip se in soundEffects)
        {
            if (se.name == name)
            {
                audioSource.PlayOneShot(se);
                //Debug.Log(se.name);
            }
        }
    }
   public void PlaySoundLoop(string name,Transform transform)
    {
        foreach (AudioClip se in soundEffects)
        {
            if (se.name == name)
            {
                AudioSource audio = transform.GetComponent<AudioSource>();
                audio.clip = se;
                audio.Play();
            }
        }
    }
    public void StopSoundLoop(string name, Transform transform)
    {
       
        AudioSource audio = transform.GetComponent<AudioSource>();
        if(audio.clip.name== name)
        {
            audio.Stop();
        }
       
    }
}
