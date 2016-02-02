using UnityEngine;
using System.Collections;

public class RitualDisplay : MonoBehaviour
{

	public GameObject[] Positions;
	public GameObject[] Stones;
	Tower tower;

	// Use this for initialization
	void Start ()
	{
		if (tower == null) {
			tower = GameObject.FindGameObjectWithTag ("Tower").GetComponent<Tower> ();

		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckCurrentSpell (tower.isPaused);
	}

	void CheckCurrentSpell (bool paused)
	{
		if (!paused) {
			if (tower.CurrentProjectile == tower.projectiles [0]) {
				for (int i = 0; i < Stones.Length; i++) {
					Stones [i].transform.parent = Positions [i].transform;
					Stones [i].transform.position = Positions [i].transform.position;
				}
			} else if (tower.CurrentProjectile == tower.projectiles [1]) {
				Stones [0].transform.parent = Positions [3].transform;
				Stones [0].transform.position = Positions [3].transform.position;	
				Stones [1].transform.parent = Positions [2].transform;
				Stones [1].transform.position = Positions [2].transform.position;	
				Stones [2].transform.parent = Positions [1].transform;
				Stones [2].transform.position = Positions [1].transform.position;	
				Stones [3].transform.parent = Positions [0].transform;
				Stones [3].transform.position = Positions [0].transform.position;	
			} else if (tower.CurrentProjectile == tower.projectiles [2]) {
				Stones [0].transform.parent = Positions [0].transform;
				Stones [0].transform.position = Positions [0].transform.position;	
				Stones [1].transform.parent = Positions [2].transform;
				Stones [1].transform.position = Positions [2].transform.position;	
				Stones [2].transform.parent = Positions [3].transform;
				Stones [2].transform.position = Positions [3].transform.position;	
				Stones [3].transform.parent = Positions [1].transform;
				Stones [3].transform.position = Positions [1].transform.position;	
			}
		}
	}
}
