using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	public Text GameOver;
	public Text RestartQuit;
	public Text ScoreText;

	int score;
	private static int best_score = 0;

	void Start () {
		score = UFOController.score;
		check_score();
		ScoreText.text = "Score: " + score.ToString() + "\nBest Score: " + best_score.ToString();
	}

	void Update () {
		if (Input.GetKey(KeyCode.R)) {
			SceneManager.LoadScene(1);
		} else if (Input.GetKey(KeyCode.Q)) {
			GameOver.fontSize = 70;
			GameOver.text = "Thank you for playing game";
			ScoreText.text = "Best Score: " + best_score.ToString();
			RestartQuit.text = "";

			Application.Quit();
		}
	}

	void check_score() {
		if (score > best_score) {
			best_score = score;
		}
	}
}
