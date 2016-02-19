using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuUIManager : MonoBehaviour
{

	public GameObject MM;
	public GameObject OP;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}


	public void Back ()
	{
		MM.SetActive (true);
		OP.SetActive (false);
	}

	public void Options ()
	{
		OP.SetActive (true);
		MM.SetActive (false);
	}

	public void PlayGame ()
	{
		Invoke ("LoadLevel", 0.5f);
	}

	public void ExitGame ()
	{
		Application.Quit ();
	}

	void OnLevelWasLoaded (int level)
	{
		if (level == 0) {
			
		}	
	}

	public void LoadLevel ()
	{
		Debug.Log ("Invoking LoadLevel");
		SceneManager.LoadScene ("GameLevel");
	}

}
