using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public GameObject TowerObject;
	public float speed;
	public float DealDamage = 10;
	Rigidbody2D rb;
	Tower tw;
	Quaternion rotation;
	AudioSource DeathAudio;
	public GameObject Splat;

	public Transform target;
	private Vector3 v_diff;
	private float atan2;
	public bool ableToMove = true;

	// Use this for initialization
	void Start ()
	{
		if (target == null) {
			target = GameObject.FindGameObjectWithTag ("Tower").transform;
			TowerObject = target.gameObject;
			tw = TowerObject.GetComponent<Tower> ();
		} else {
			tw = TowerObject.GetComponent<Tower> ();
		}
		DeathAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		LookAtTower ();
		MoveForward (ableToMove);
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Tower") {
			tw.Damage (DealDamage);
			DeathAudio.Play ();
			Camera.main.GetComponent<Spawn> ().BugKilled ();
			Destroy (this.gameObject, DeathAudio.clip.length);
		}
	}

	void LookAtTower ()
	{
		v_diff = (target.position - transform.position);    
		atan2 = Mathf.Atan2 (v_diff.y, v_diff.x);
		transform.rotation = Quaternion.Euler (0f, 0f, atan2 * Mathf.Rad2Deg);
	}

	void MoveForward (bool canMove)
	{
		if (canMove)
			transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
	}

	void OnDestroy ()
	{
		Instantiate (Splat, transform.position, transform.rotation);
		//DeathAudio.enabled = true;
	}
}
