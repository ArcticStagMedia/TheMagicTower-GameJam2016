using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

	public AudioSource Music;
	public AudioSource SoundEffects;

	public float MusicVolume;
	public float SFXVolume;

	public AudioClip MainMenuMusic;
	public AudioClip GameMusic;
	public AudioClip GameOverMusic;

	public AudioClip[] BugDeathSounds;
	public AudioClip[] ProjectileSFX;

	// Use this for initialization
	void Start ()
	{
		if (GameManager.Instance.audioManager != this) {
			Destroy (this);
		} else if (GameManager.Instance.audioManager == null) {
			GameManager.Instance.audioManager = this;
			DontDestroyOnLoad (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void SetVolume ()
	{
		Music.volume = MusicVolume;
		SoundEffects.volume = SFXVolume;
	}

	public void BugDeathSFX ()
	{
		SoundEffects.PlayOneShot (BugDeathSounds [Random.Range (0, BugDeathSounds.Length)]);
		return;
	}

	public void PlaySFX (int sfx)
	{
		SoundEffects.PlayOneShot (ProjectileSFX [sfx]);
		return;
	}

	void OnLevelWasLoaded (int level)
	{
		switch (level) {
		case 0:
			Music.clip = MainMenuMusic;
			Music.Play ();
			Music.loop = true;
			break;
		case 1:
			Music.clip = GameMusic;
			Music.Play ();
			Music.loop = true;
			break;
		case 2:
			Music.clip = GameOverMusic;
			Music.Play ();
			Music.loop = true;
			break;
		}
	}
}
