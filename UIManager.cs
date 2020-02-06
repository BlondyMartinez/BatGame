using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private InputField inputField;
    [SerializeField] private GameObject scoreboardPanel, endScreenPanel, menuPanel, pausePanel;
    [SerializeField] private Text scoreboardText, scoreText;

    private bool isPaused = false;


    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            Pause();
        }
    }

    public void Next() {
        scoreboardText.text = GameController.score.ToString();

        GameController.names[3] = inputField.text;
        GameController.scores[3] = GameController.score;

        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                if (GameController.scores[i] > GameController.scores[j]) {
                    int scoresTemp = GameController.scores[i];
                    string nameTemp = GameController.names[i];
                    GameController.scores[i] = GameController.scores[j];
                    GameController.scores[j] = scoresTemp;
                    GameController.names[i] = GameController.names[j];
                    GameController.names[j] = nameTemp;
                }
            }
        }

        for (int i = 0; i < 4; i++) {
            string scoresTemp = "score" + i;
            string nameTemp = "name" + i;
            PlayerPrefs.SetInt(scoresTemp, GameController.scores[i]);
            PlayerPrefs.SetString(nameTemp, GameController.names[i]);
        }

        ScoreboardButton();
    }

    public void Play() {
        menuPanel.SetActive(false);
        scoreboardPanel.SetActive(false);
        endScreenPanel.SetActive(false);
        GameController.score = 0;
        scoreText.text = "SCORE: " + 0;
        Spawn.time = 4;
        GameController.gameEnded = false;
        pausePanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }

    public void ScoreboardButton() {
        menuPanel.SetActive(false);
        endScreenPanel.SetActive(false);
        scoreboardPanel.SetActive(true);
        scoreboardText.text = "1. " + GameController.names[0] + " " + GameController.scores[0] + "\n" +
            "2. " + GameController.names[1] + " " + GameController.scores[1] + "\n" +
            "3. " + GameController.names[2] + " " + GameController.scores[2] + "\n";
    }

    public void Menu() {
        menuPanel.SetActive(true);
        scoreboardPanel.SetActive(false);
        endScreenPanel.SetActive(false);
        pausePanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }

    public void Quit() {
        Application.Quit();
    }

    public void Pause() {
        isPaused = !isPaused;
        if (isPaused) {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        } else {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        EventSystem.current.SetSelectedGameObject(null);
    }
}
