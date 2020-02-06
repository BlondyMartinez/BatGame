using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

    private void Update() {

        transform.position += Vector3.left * Time.deltaTime;

        if (transform.position.x  <= - 20 || GameController.gameEnded) {
            Destroy(gameObject);
        }
    }
}
