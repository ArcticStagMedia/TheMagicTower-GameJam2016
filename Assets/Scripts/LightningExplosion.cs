using UnityEngine;
using System.Collections;

public class LightningExplosion : MonoBehaviour
{

	public float ExplosionTime;

	// Use this for initialization
	void Start ()
	{
        GameManager.Instance.PlaySFX(3);
        StartCoroutine (Explode ());
	}

	IEnumerator Explode ()
	{
		yield return new WaitForSeconds (ExplosionTime);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
        Death(other);
    }

	void OnTriggerExit2D (Collider2D other)
	{
        Death(other);
    }

	void OnTriggerStay2D (Collider2D other)
	{
        Death(other);	
	}

    void Death(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyTwo" || other.gameObject.tag == "EnemyThree")
        {
            GameManager.Instance.BugDeathSFX();
            Camera.main.GetComponent<Spawn>().BugKilled();
            Destroy(other.gameObject);
        }
    }
}
