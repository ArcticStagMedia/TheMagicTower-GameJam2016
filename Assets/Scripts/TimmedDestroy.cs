using UnityEngine;
using System.Collections;

public class TimmedDestroy : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (Destroy ());
	}

	IEnumerator Destroy ()
	{
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
}
