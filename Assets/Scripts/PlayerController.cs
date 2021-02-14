using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float velocity;

    [SerializeField]
    private Rigidbody2D _rigidBody2D;

    private void Update() {

		if(Input.GetKey(KeyCode.LeftArrow)) {
			_rigidBody2D.velocity = Vector2.left * velocity;
		} else if(Input.GetKey(KeyCode.RightArrow)) {
			_rigidBody2D.velocity = Vector2.right * velocity;
		} else {
			_rigidBody2D.velocity = Vector2.zero;
		}

	}

	public void Default() {
		_rigidBody2D.velocity = Vector2.zero;

		Vector2 position = _rigidBody2D.position;
		position.x = 0f;
		_rigidBody2D.MovePosition(position);
	}

}