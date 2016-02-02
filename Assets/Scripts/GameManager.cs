using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private float health = 100;
    private float maxHealth = 100f;
    public int Score;
    public int Wave;

    public AudioSource Music;
    public AudioSource SoundEffects;

    public float MusicVolume;
    public float SFXVolume;

    public AudioClip MainMenuMusic;
    public AudioClip GameMusic;
    public AudioClip GameOverMusic;

    public AudioClip[] BugDeathSounds;
    public AudioClip[] ProjectileSFX;

    void Awake()
    {



    }
    // Use this for initialization
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


    }

    // Update is called once per frame
    void Update()
    {

        health = Mathf.Clamp(health, 0f, maxHealth);
        CheckGameOver(health);
        SetVolume();
    }

    void SetVolume()
    {
        Music.volume = MusicVolume;
        SoundEffects.volume = SFXVolume;
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float h)
    {
        health = h;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void GetMaxHealth(float mh)
    {
        maxHealth = mh;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameLevel()
    {
        this.GetComponent<Spawn>().enabled = true;
        SceneManager.LoadScene("GameLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void CheckGameOver(float h)
    {
        if (h <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void BugDeathSFX()
    {
        SoundEffects.PlayOneShot(BugDeathSounds[Random.Range(0, BugDeathSounds.Length)]);
        return;
    }

    public void PlaySFX(int sfx)
    {
        SoundEffects.PlayOneShot(ProjectileSFX[sfx]);
        return;
    }

    void OnLevelWasLoaded(int level)
    {
        switch (level)
        {
            case 0:
                Music.clip = MainMenuMusic;
                Music.Play();
                Music.loop = true;
                break;
            case 1:
                Music.clip = GameMusic;
                Music.Play();
                Music.loop = true;
                break;
            case 2:
                Music.clip = GameOverMusic;
                Music.Play();
                Music.loop = true;
                break;
        }
    }
}
