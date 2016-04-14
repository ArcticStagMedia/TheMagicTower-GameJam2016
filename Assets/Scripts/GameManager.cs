using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
	INTRO,
	MAIN_MENU,
	PAUSED,
	GAME,
	CREDITS,
	HELP

}

public delegate void OnStateChangeHandler ();

public class GameManager: Object
{

	private float health = 100;
	private float maxHealth = 100f;
	public int Score;
	public int Wave;
	public AudioManager audioManager;

	protected GameManager ()
	{
	}

	private static GameManager instance = null;

	public event OnStateChangeHandler OnStateChange;

	public  GameState gameState { get; private set; }

	public static GameManager Instance {
		get {
			if (GameManager.instance == null) {
				GameManager.instance = new GameManager ();
				DontDestroyOnLoad (GameManager.instance);
			}
			return GameManager.instance;
		}

	}

	public void SetGameState (GameState state)
	{
		this.gameState = state;
		OnStateChange ();
	}

	public void OnApplicationQuit ()
	{
		GameManager.instance = null;
	}

	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		health = Mathf.Clamp (health, 0f, maxHealth);
		CheckGameOver (health);
	}


	public float GetHealth ()
	{
		return health;
	}

	public void SetHealth (float h)
	{
		health = h;
	}

	public float GetMaxHealth ()
	{
		return maxHealth;
	}

	public void GetMaxHealth (float mh)
	{
		maxHealth = mh;
	}

	void CheckGameOver (float h)
	{
		if (h <= 0) {
			SceneManager.LoadScene ("GameOver");
		}
	}


   
}
