using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMain : MonoBehaviour {
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("Main");
        }
    }

}