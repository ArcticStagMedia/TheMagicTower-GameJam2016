using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance = null;

	private float health = 100;
	private float maxHealth = 100f;
	public int Score;
	public int Wave;

	public AudioSource Music;
	public AudioSource SoundEffects;

	public AudioClip MainMenuMusic;
	public AudioClip GameMusic;
	public AudioClip GameOverMusic;

	void Awake ()
	{
		


	}
	// Use this for initialization
	void Start ()
	{
		if (Instance == null) {
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);


	}
	
	// Update is called once per frame
	void Update ()
	{

		health = Mathf.Clamp (health, 0f, maxHealth);
		CheckGameOver (health);
		if (SceneManager.GetActiveScene ().name == "GameOver") {

		}
	}

	public float GetHealth ()
	{
		return health;
	}

	public void SetHealth (float h)
	{
		health = h;
	}

	public float GetMaxHealth ()
	{
		return maxHealth;
	}

	public void GetMaxHealth (float mh)
	{
		maxHealth = mh;
	}

	public void LoadMainMenu ()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void LoadGameLevel ()
	{
		this.GetComponent<Spawn> ().enabled = true;
		SceneManager.LoadScene ("GameLevel");
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}

	void CheckGameOver (float h)
	{
		if (h <= 0) {
			SceneManager.LoadScene ("GameOver");
		}
	}

	void OnLevelWasLoaded (int level)
	{
		switch (level) {
		case 0:
			Music.clip = MainMenuMusic;
			Music.Play ();
			break;
		case 1:
			Music.clip = GameMusic;
			Music.Play ();
			break;
		case 2:
			Music.clip = GameOverMusic;
			Music.Play ();
			break;
		}
	}
}
