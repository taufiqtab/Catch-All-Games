using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] ObjectToSpawn;

    public int[] randomSecond;

    
	// Use this for initialization
	void Start () {
        Invoke("SpawnObject", randomSecond[Random.Range(0, randomSecond.Length)]);
	}


    public void SpawnObject()
    {
        if (GamesManager.Instance.isGameOver) return;
        Instantiate(ObjectToSpawn[Random.Range(0, ObjectToSpawn.Length)], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        Invoke("SpawnObject", randomSecond[Random.Range(0, randomSecond.Length)]);
    }
}
