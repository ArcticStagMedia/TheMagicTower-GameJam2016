using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadOptionsMenu : MonoBehaviour
{

    GameManager gm;

    public Slider Music;
    public Slider SFX;

    // Use this for initialization
    void Start()
    {
        if (gm == null)
        {
            gm = GameManager.Instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ConnectAudio();
    }

    void ConnectAudio()
    {
        gm.MusicVolume = Music.value;
        gm.SFXVolume = SFX.value;
    }
}
