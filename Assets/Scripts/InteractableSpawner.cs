using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSpawner : MonoBehaviour {

	// Probability controls for spawning humans and legos
	public float pSpawnHuman;	// [0, 100], 0 = never spawn, 100 = always spawn
	public float pSpawnLego;	// [0, 100], 0 = never spawn, 100 = always spawn

	// Interactable object prefabs
	public GameObject human;
	public GameObject lego;

	// Object pool for interactable objects
	public List<GameObject> humanObjPool;
	public List<GameObject> legoObjPool;
	public int maxObjects;

	// Use this for initialization
	void Start () {
		CreateObjectPools ();
	}

	public GameObject SpawnObjectAtPositionAtGivenProbability (Vector3 position) {
		float spawnHumanRNG = Random.Range (0f, 100f);
		float spawnLegoRNG = Random.Range (0f, 100f);

		if (spawnHumanRNG <= pSpawnHuman) {
			GameObject humanObj = GetHumanFromPool ();
			if (humanObj != null) {
				humanObj.transform.position = position;
				humanObj.SetActive (true);
			}

			return humanObj;
		} else if (spawnLegoRNG <= pSpawnLego) {
			GameObject legoObj = GetLegoFromPool ();
			if (legoObj != null) {
				legoObj.transform.position = position;
				legoObj.SetActive (true);
			}

			return legoObj;
		} else {
			return null;
		}
	}

	public void CreateObjectPools () {
		humanObjPool = new List<GameObject> ();
		legoObjPool = new List<GameObject> ();

		for (int i = 0; i < maxObjects; i++) {
			humanObjPool.Add (Instantiate (human));
			legoObjPool.Add (Instantiate (lego));
		}
	}

	GameObject GetHumanFromPool () {
		for (int i = 0; i < maxObjects; i++) {
			if (!humanObjPool [i].activeSelf) {
				return humanObjPool [i];
			}
		}

		return null;
	}

	GameObject GetLegoFromPool () {
		for (int i = 0; i < maxObjects; i++) {
			if (!legoObjPool [i].activeSelf) {
				return legoObjPool [i];
			}
		}

		return null;
	}
}
