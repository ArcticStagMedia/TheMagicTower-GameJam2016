using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderFindAudioManager : MonoBehaviour
{

	private float sliderVolume;

	public enum VolumeType
	{
		Music,
		SFX
	}

	public VolumeType VolType = VolumeType.Music;



	private AudioManager am;

	// Use this for initialization
	void Start ()
	{
		if (am == null) {
			am = GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<AudioManager> ();
			Debug.Log ("Found AudioManager");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		sliderVolume = GetComponent<Slider> ().value;
		VolumeRelay (VolType);
	}

	void VolumeRelay (VolumeType v)
	{
		switch (v) {
		case VolumeType.Music:
			am.MusicVolume = sliderVolume;
			break;
		case VolumeType.SFX:
			am.SFXVolume = sliderVolume;
			break;
		}
	}
}
