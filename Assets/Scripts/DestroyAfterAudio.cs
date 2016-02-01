using UnityEngine;
using System.Collections;

public class DestroyAfterAudio : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
	{
		if (transform.parent == null) {
			if (!GetComponent<AudioSource> ().isPlaying) {
				Destroy (this.gameObject);
			}
		}
	}
}
