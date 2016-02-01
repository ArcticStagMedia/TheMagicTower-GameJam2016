using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuUIManager : MonoBehaviour
{

	public Canvas MM;
	public Canvas OP;

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
		MM.gameObject.SetActive (true);
		OP.gameObject.SetActive (false);
	}

	public void Options ()
	{
		OP.gameObject.SetActive (true);
		MM.gameObject.SetActive (false);
	}

	public void PlayGame ()
	{
		SceneManager.LoadScene ("GameLevel");
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

}
