using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public float waitTime;

    public GameObject[] powerUps;

    static int spawn = 0;

    void Update() {
        if (spawn < 3)
            StartCoroutine("CreatePowerUp");
    }

    Transform GetSpawnPoint()
    {
        int maxNum = gameObject.transform.childCount;
        int randomNum = Random.Range(0, maxNum);
        return gameObject.transform.GetChild(randomNum);
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
        Instantiate(GetPowerUp(), GetSpawnPoint().position, GetSpawnPoint().rotation);
    }

    public static void Spawn()
    {
        spawn -= 1;
    }        
}
