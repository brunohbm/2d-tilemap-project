using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnController : MonoBehaviour {

    public float waitTime;

    public GameObject[] powerUps;

    static int spawn = 0;    

    void Update() {
        if (spawn < 3)
            StartCoroutine("CreatePowerUp");
    }

    Transform GetSpawnPoint()
    {
        Transform newSpawnPoint;

        do {
            int maxNum = gameObject.transform.childCount;
            int randomNum = Random.Range(0, maxNum);
            newSpawnPoint = gameObject.transform.GetChild(randomNum);
        } while (newSpawnPoint.childCount > 0);

        return newSpawnPoint;
    }

    GameObject GetPowerUp()
    {        
        int maxNum = powerUps.Length;
        int randomNum = Random.Range(0, maxNum);
        return powerUps[randomNum];
    }

    IEnumerator CreatePowerUp()
    {        
        spawn += 1;
        yield return new WaitForSeconds(waitTime);
        Transform spawnPoint = GetSpawnPoint();
        Instantiate(GetPowerUp(), spawnPoint.position, spawnPoint.rotation, spawnPoint);
    }

    public static void Spawn()
    {
        spawn -= 1;
    }        
}
