using UnityEngine;
using System.Collections;

public class SpawnManagerCode : MonoBehaviour {
	
	public GameObject steve;
	public float time = 5f;
	public Transform[] spawnPoints;
	private int count = 0;
	public int max = 5;

	void Start () {
		InvokeRepeating ("Spawn", 0, time);
	}

	void Spawn () {
		if (count < max) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate (steve, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			count++;
		} else if (explosionTrigger.alive == false) {
			Debug.Log ("explosion");
			count--;
		}
	}
}

