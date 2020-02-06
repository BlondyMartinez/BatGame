using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    [SerializeField] GameObject[] enemies;
    public static float time = 4;
	
	// Update is called once per frame
	void Update () {
		if (time <= 0 && !GameController.gameEnded) {
            int x = Random.Range(0, 8);
            Instantiate(enemies[x], new Vector3(transform.position.x, enemies[x].transform.position.y, 2), Quaternion.identity);
            time = 8;
        }

        time -= Time.deltaTime;
	}
}
