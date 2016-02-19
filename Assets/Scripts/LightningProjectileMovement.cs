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
		GameManager.Instance.audioManager.PlaySFX (2);
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.up * MovementSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "EnemyTwo" || other.gameObject.tag == "EnemyThree") {
			Camera.main.GetComponent<Spawn> ().BugKilled ();
			GameManager.Instance.audioManager.BugDeathSFX ();
			Destroy (other.gameObject);
			GameManager.Instance.Score++;
			Instantiate (LightningExplosions, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
	}
}
