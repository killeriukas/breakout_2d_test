using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _velocity;

    [SerializeField]
    private Rigidbody2D _rigidBody2D;

    private void Update() {

		if(Input.GetKey(KeyCode.LeftArrow)) {
			_rigidBody2D.velocity = Vector2.left * _velocity;
		} else if(Input.GetKey(KeyCode.RightArrow)) {
			_rigidBody2D.velocity = Vector2.right * _velocity;
		} else {
			_rigidBody2D.velocity = Vector2.zero;
		}

	}

}