using UnityEngine;

public class BallController : MonoBehaviour {

    [SerializeField]
    private float velocity;

    [SerializeField]
    private Rigidbody2D _rigidBody2D;

    public void Kick() {
        Vector2 moveDirection = Random.insideUnitCircle.normalized;
        _rigidBody2D.velocity = moveDirection * velocity;
    }

	public void Default() {
        _rigidBody2D.velocity = Vector2.zero;
        _rigidBody2D.MovePosition(Vector2.zero);
    }

}