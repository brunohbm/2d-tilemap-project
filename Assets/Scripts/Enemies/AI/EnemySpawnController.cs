using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

    public GameObject enemyPrefab;

    public float spawnInterval;
    public int enemiesToSpawn;

    bool spawning;

    void Start () {}
		
	void Update () {
        if (enemiesToSpawn > 0 && spawning == false)
        {
            StartCoroutine("SpawnEnemy");
        }
	}

    IEnumerator SpawnEnemy()
    {
        spawning = true;
        Instantiate(enemyPrefab, transform.position, transform.rotation, transform);
        enemiesToSpawn--;
        yield return new WaitForSeconds(spawnInterval);
        spawning = false;
    }
}
