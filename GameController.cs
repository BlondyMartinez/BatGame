using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static bool gameEnded = true;
    private float time = 2;

    public static int score;
    public Text scoreText;
    public Text endScreenText;
    [SerializeField] private GameObject endScreen;

    public static int[] scores = new int[4];
    public static string[] names = new string[4];

    private void Start() {
        for (int i = 0; i < 4; i++) {
            string temp = "score" + i;
            if (PlayerPrefs.HasKey(temp)) {
                scores[i] = PlayerPrefs.GetInt(temp);
                string nameTemp = "name" + i;
                names[i] = PlayerPrefs.GetString(nameTemp);
            } else {
                scores[i] = 0;
                names[i] = " ";
            }
        }
    }

    // Update is called once per frame
    void Update () {
		if (!gameEnded) {
            if (time <= 0) {
                score++;
                scoreText.text = "SCORE: " + score;
                time = 2;
            }
            time -= Time.deltaTime;
        } else {
            endScreen.SetActive(true);
            endScreenText.text = "SCORE: " + score;
        }
	}
}
