using UnityEngine;

public class DeathController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        GamePlay gameManager = GamePlay.instance;

        gameManager.MarkAsDied();

        if(gameManager.HasEnoughLives) {
            gameManager.Restart();
        }
        
    }

}