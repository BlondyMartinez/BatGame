using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    float scrollSpeed = 0.5f;
    public float tileSizeZ;

    private Vector3 startPosition;

    void Start() {
        startPosition = transform.position;
    }

    void Update() {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
