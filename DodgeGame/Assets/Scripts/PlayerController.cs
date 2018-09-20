using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;

    private Rigidbody2D player;

    Vector2 MoveVelocity;

	void Start () {
        player = GetComponent<Rigidbody2D>();
	}

    void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        MoveVelocity = movement * speed;

        player.transform.Rotate(0, 0, 0.1f);
        player.MovePosition(player.position + MoveVelocity * Time.fixedDeltaTime);

        player.transform.position = new Vector2(
            Mathf.Clamp(player.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(player.position.y, boundary.yMin, boundary.yMax));
    }
}