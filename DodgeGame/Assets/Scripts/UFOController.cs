using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UFOController : MonoBehaviour {

	public Text LifeText;
	public static int score;
	public int life;

	private float ufox;
	private float ufoy;
	private Rigidbody2D ufo;

	void Start () {
		ufo = GetComponent<Rigidbody2D>();
		spawn();

		score = 0;
		EndScene();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
			spawn();

			score++;
			EndScene();
		} else if (other.gameObject.CompareTag("stone")) {
			spawn();

			life--;
			EndScene();
		}
    }

	void spawn() {
		ufox = Random.Range(-40.0f, 40.0f);
		ufoy = Random.Range(-20.0f, 20.0f);

		ufo.transform.position = new Vector2(ufox, ufoy);
	}

	void EndScene() {
		LifeText.text = "Life: " + life.ToString() + " Score: " + score.ToString();

		if (life <= 0) {
			SceneManager.LoadScene(2);
		}
	}
}
