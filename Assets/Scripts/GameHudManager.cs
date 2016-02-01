using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHudManager : MonoBehaviour
{
	GameManager gm;

	public Text HealthText;
	public Text Score;
	public Text Waves;

	// Use this for initialization
	void Start ()
	{
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		HealthText.text = "Health: " + Mathf.Clamp (gm.GetHealth (), 0, gm.GetMaxHealth ()).ToString ();
		Score.text = "Score: " + GameManager.Instance.Score.ToString ();
		Waves.text = "Wave: " + GameManager.Instance.Wave.ToString ();
	}
}
