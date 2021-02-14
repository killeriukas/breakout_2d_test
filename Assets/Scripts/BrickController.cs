using UnityEngine;

public class BrickController : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other) {
        GamePlay.instance.MarkAsScored();
        Destroy(gameObject);
    }

}