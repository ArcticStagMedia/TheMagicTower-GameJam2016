using UnityEngine;
using System.Collections;

public class IceProjectileMovement : MonoBehaviour
{

	public float MovementSpeed;

	Rigidbody2D rgb2d;
	// Use this for initialization
	void Start ()
	{
		GameManager.Instance.audioManager.PlaySFX (1);
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.up * MovementSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "EnemyOne" || other.gameObject.tag == "EnemyTwo") {
			GameManager.Instance.audioManager.BugDeathSFX ();
			Camera.main.GetComponent<Spawn> ().BugKilled ();
			Destroy (other.gameObject);
			GameManager.Instance.Score++;
		}
	}
}
