using UnityEngine;
using System.Collections;

public class LightningProjectileMovement : MonoBehaviour
{

	public float MovementSpeed;
	public GameObject LightningExplosions;

	Rigidbody2D rgb2d;
	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.up * MovementSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "EnemyTwo" || other.gameObject.tag == "EnemyThree") {
			other.GetComponent<AudioSource> ().Play ();
			other.GetComponent<Enemy> ().ableToMove = false;
			other.GetComponentInChildren<SpriteRenderer> ().color = new Color (84 / 255, 56 / 255, 65 / 255);
			Camera.main.GetComponent<Spawn> ().BugKilled ();
			Destroy (other.gameObject, other.GetComponent<AudioSource> ().clip.length);
			GameManager.Instance.Score++;
			Instantiate (LightningExplosions, transform.position, transform.rotation);
			transform.DetachChildren ();
			Destroy (this.gameObject);
		}
	}
}
