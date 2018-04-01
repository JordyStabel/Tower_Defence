using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

	// Use this for initialization
	void Awake () {
		foreach (Sound sound in sounds)
        {
            //Set the correct audio source file for each audio in the array
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.audioClip;

            //Set volume and pitch
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
	}
	
	public void Play(string nameSound)
    {
        //Find the correct sound and play it
        Sound _sound = Array.Find(sounds, sound => sound.name == nameSound);
        _sound.source.Play();
    }
}