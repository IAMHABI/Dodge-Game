using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour {

    public float speed;

    private float rot;
    private Rigidbody2D stone;
    private float sx;
    private float sy;

    Vector2 MoveVelocity;

    void Start () {
        stone = GetComponent<Rigidbody2D>();
        rot = 0.98f;

        Move();
    }	

    void FixedUpdate () {
        if (stone.position.x < -55) {
            Move(sx, 32.0f);
        } else if (stone.position.x > 55) {
            Move(sx, -32.0f);
        }

        if (stone.position.y < -35) {
            Move(55.0f, sy);
        } else if (stone.position.y > 35) {
            Move(-55.0f, sy);
        }

        stone.transform.Rotate(0, 0, rot);
        stone.MovePosition(stone.position + MoveVelocity * Time.fixedDeltaTime);
    }

    void Move() {
        sx = Random.Range(-50, 50);
        sy = Random.Range(-28, 28);

        Vector2 movement = new Vector2(sx, sy);
        MoveVelocity = movement * speed;
    }

    void Move(float x, float y) {
        sx = Random.Range(-50, 50);
        sy = Random.Range(-28, 28);

        Vector2 movement = new Vector2(sx, sy);
        MoveVelocity = movement * speed;

        stone.transform.position = new Vector2(x, y);
        stone.MovePosition(stone.position + MoveVelocity * Time.fixedDeltaTime);
    }
}