using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tower : MonoBehaviour
{

	GameManager gameManager;
	float CurrentHealth;
	public GameObject projectileSpawn;
	public GameObject CurrentProjectile;
	public GameObject[] projectiles;
	public GameObject[] inertStones;
	public GameObject[] ActiveStones;
	public GameObject CurrentActiveStone;

	public Text errotText;

	public GameObject pauseMenu;

	public bool isPaused;
	string ritualString = null;
	bool ritualPassed = false;

	// Use this for initialization
	void Start ()
	{
		if (gameManager == null) {
			gameManager = GameManager.Instance;
		}
		CurrentHealth = gameManager.GetHealth ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ritualString != null) {
			errotText.text = "Current ritual section: " + ritualString.Length.ToString ();
		} else {
			errotText.text = "";
		}

		ritualPassed = Ritual (CurrentProjectile);
		gameManager.SetHealth (CurrentHealth);
		LookAtMouse (isPaused);
		if (Input.GetButtonDown ("Fire1") && ritualPassed) {
			GameObject clone;
			clone = Instantiate (CurrentProjectile, projectileSpawn.transform.position, new Quaternion (0, 0, transform.rotation.z, transform.rotation.w)) as GameObject;
			clone.name = CurrentProjectile.name;
			ritualString = null;
		}
		if (Input.GetButtonDown ("Pause")) {
			isPaused = !isPaused;
		}
		if (isPaused) {
			ActivatePauseMenu (isPaused);
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
		SwitchSpell (isPaused);
		ActivatePauseMenu (isPaused);
	}

	public void Damage (float DamageTaken)
	{
		CurrentHealth = CurrentHealth - DamageTaken;
	}

	void LookAtMouse (bool Paused)
	{
		if (!Paused) {
			Vector3 mousePosition = Input.mousePosition;           
			mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);

			//transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, transform.position.x));
			Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
			transform.rotation = rot;  
			transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		}
	}

	void SwitchSpell (bool paused)
	{
		if (!paused) {
			if (Input.GetKeyDown (KeyCode.Tab)) {
				if (CurrentActiveStone == ActiveStones [0]) {
					CurrentActiveStone.SetActive (false);
					inertStones [0].SetActive (true);
					CurrentActiveStone = ActiveStones [1];
					CurrentActiveStone.SetActive (true);
					CurrentProjectile = projectiles [1];

				} else if (CurrentActiveStone == ActiveStones [1]) {
					CurrentActiveStone.SetActive (false);
					inertStones [1].SetActive (true);
					CurrentActiveStone = ActiveStones [2];
					CurrentActiveStone.SetActive (true);
					CurrentProjectile = projectiles [2];
				} else if (CurrentActiveStone == ActiveStones [2]) {
					CurrentActiveStone.SetActive (false);
					inertStones [2].SetActive (true);
					CurrentActiveStone = ActiveStones [0];
					CurrentActiveStone.SetActive (true);
					CurrentProjectile = projectiles [0];
				} else {
					print ("***ERROR*** No match in current active stone Tower.cs");
				}
			}
		}
	}

	bool Ritual (GameObject ActiveSpell)
	{
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			ritualString = null;
		}
		if (isPaused) {
			return false;
		}
		if (ActiveSpell == projectiles [0]) {

			for (KeyCode i = KeyCode.A; i < KeyCode.Z; i++) {
				if (Input.GetKeyDown (i))
					ritualString += i.ToString ();
			}
			if (ritualString == null) {
				return false;
			}
			if (ritualString.Length > 4) {
				ritualString = null;
			}
			if (ritualString.Length == 4 && ritualString == "QWER") {
				return true;
			} else if (ritualString.Length < 4) {
				return false;
			} else {
				ritualString = null;
				return false;
			}
		} else if (ActiveSpell == projectiles [1]) {
			for (KeyCode i = KeyCode.A; i < KeyCode.Z; i++) {
				if (Input.GetKeyDown (i))
					ritualString += i.ToString ();
			}
			if (ritualString == null) {
				return false;
			}
			if (ritualString.Length > 4) {
				ritualString = null;
			}
			if (ritualString.Length == 4 && ritualString == "REWQ") {
				return true;
			} else if (ritualString.Length < 4) {
				return false;
			} else {
				ritualString = null;
				return false;
			}
		} else if (ActiveSpell == projectiles [2]) {
			for (KeyCode i = KeyCode.A; i < KeyCode.Z; i++) {
				if (Input.GetKeyDown (i))
					ritualString += i.ToString ();
			}
			if (ritualString == null) {
				return false;
			}
			if (ritualString.Length > 4) {
				ritualString = null;
			}
			if (ritualString.Length == 4 && ritualString == "QRWE") {
				return true;
			} else if (ritualString.Length < 4) {
				return false;
			} else {
				ritualString = null;
				return false;
			}
		} else {
			print ("***ERROR*** No match in current active stone Tower.cs");
			return false;
		}
	}

	void ActivatePauseMenu (bool paused)
	{
		if (paused) {
			pauseMenu.SetActive (true);
		} else {
			pauseMenu.SetActive (false);
		}
	}

	public void Resume ()
	{
		isPaused = false;
	}

}
