using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverUIManager : MonoBehaviour
{
	
	public Text WavesDone;
	public Text Score;

	// Use this for initialization
	void Start ()
	{
		GameManager.Instance.SetHealth (GameManager.Instance.GetMaxHealth ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		WavesDone.text = "You completed " + (GameManager.Instance.Wave - 1).ToString () + " waves!";
		Score.text = "Your score was: " + GameManager.Instance.Score.ToString () + "!";
	}

	public void LoadMain ()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
