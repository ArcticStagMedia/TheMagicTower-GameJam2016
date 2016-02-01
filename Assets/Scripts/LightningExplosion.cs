using UnityEngine;
using System.Collections;

public class LightningExplosion : MonoBehaviour
{

	public float ExplosionTime;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (Explode ());
	}

	IEnumerator Explode ()
	{
		yield return new WaitForSeconds (ExplosionTime);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "EnemyTwo" || other.gameObject.tag == "EnemyThree") {
			other.GetComponent<AudioSource> ().Play ();
			other.GetComponent<Enemy> ().ableToMove = false;
			other.GetComponentInChildren<SpriteRenderer> ().color = new Color (84 / 255, 56 / 255, 65 / 255);
			Camera.main.GetComponent<Spawn> ().BugKilled ();
			Destroy (other.gameObject, other.GetComponent<AudioSource> ().clip.length);
		}	
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag == "EnemyTwo" || other.gameObject.tag == "EnemyThree") {
			other.GetComponent<AudioSource> ().Play ();
			other.GetComponent<Enemy> ().ableToMove = false;
			other.GetComponentInChildren<SpriteRenderer> ().color = new Color (84 / 255, 56 / 255, 65 / 255);
			Camera.main.GetComponent<Spawn> ().BugKilled ();
			Destroy (other.gameObject, other.GetComponent<AudioSource> ().clip.length);
		}	
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.tag == "EnemyTwo" || other.gameObject.tag == "EnemyThree") {
			other.GetComponent<AudioSource> ().Play ();
			other.GetComponent<Enemy> ().ableToMove = false;
			other.GetComponentInChildren<SpriteRenderer> ().color = new Color (84 / 255, 56 / 255, 65 / 255);
			Camera.main.GetComponent<Spawn> ().BugKilled ();
			Destroy (other.gameObject, other.GetComponent<AudioSource> ().clip.length);
		}	
	}
}
