using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Spawn : MonoBehaviour
{

	float screenXMax = Screen.width + 50;
	float spawnXMax = Screen.width + 100;
	float screenXMin = -50;
	float SpawnXMin = -100;
	float screenYMax = Screen.height + 50;
	float SpawnYMax = Screen.height + 100;
	float screenYMin = -50;
	float SpawnYMin = -100;

	public int spawnNumber;

	public int thisWave = 0;
	public int maxWaves;
	public int startWait;
	public int spawnWait;
	public int waveWait;
	public int maxToSpawn;
	public int enemiesAlive = 0;
	public int BugsKilled = 0;

	Vector2 SpawnLoc;

	public GameObject[] enemy;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (Wave ());
	}
	
	// Update is called once per frame
	void Update ()
	{

		maxToSpawn = spawnNumber * thisWave;
		enemiesAlive = Mathf.Clamp (enemiesAlive, 0, maxToSpawn);
	}

	IEnumerator Wave ()
	{
		yield return new WaitForSeconds (startWait);
		while (SceneManager.GetActiveScene ().name == "GameLevel") {
			if (enemiesAlive == 0) {
				thisWave++;
				maxToSpawn = spawnNumber * thisWave;
				GameManager.Instance.Wave = thisWave;
				for (int i = 0; i < maxToSpawn; i++) {
					int selection = Random.Range (0, 4);
					switch (selection) {
					case 0: 
						SpawnLoc = new Vector2 (Random.Range (SpawnXMin, screenXMin), Random.Range (screenYMin, screenYMax));
						break;
					case 1:
						SpawnLoc = new Vector2 (Random.Range (screenXMax, spawnXMax), Random.Range (SpawnYMin, screenYMax));
						break;
					case 2:
						SpawnLoc = new Vector2 (Random.Range (screenXMin, screenXMax), Random.Range (SpawnYMin, screenYMin));
						break;
					case 3:
						SpawnLoc = new Vector2 (Random.Range (screenXMin, screenXMax), Random.Range (screenYMax, SpawnYMax));
						break;
					default:
						print ("Somthing fucked up in the random range in CS script 'Spawn'");
						break;
					}
					int randomEnemy = -1;
					Vector3 spawnLocation = Camera.main.ScreenToWorldPoint (new Vector3 (SpawnLoc.x, SpawnLoc.y, 0));
					randomEnemy = Random.Range (0, enemy.Length);
					Instantiate (enemy [randomEnemy], new Vector3 (spawnLocation.x, spawnLocation.y, 0), Quaternion.identity);
					enemiesAlive++;
					yield return new WaitForSeconds (spawnWait);
				}
				yield return new WaitForSeconds (waveWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void BugKilled ()
	{
		enemiesAlive--;
		BugsKilled++;

	}
		
}
