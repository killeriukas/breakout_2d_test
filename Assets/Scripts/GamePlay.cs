using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour {

    public static GamePlay instance { get; private set; }
    
    [SerializeField]
    private BallController ball;

    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private uint MaxLives = 3;

    [SerializeField]
    private TextMeshProUGUI scoreLabel;

    [SerializeField]
    private TextMeshProUGUI livesLabel;

    [SerializeField]
    private TextMeshProUGUI getReadyLabel;

    private uint currentLives;
    private uint currentScore;

    private const uint MaxBricks = 4;

    public void MarkAsScored() {
        ++currentScore;
        scoreLabel.text = "Score: " + currentScore;
    }

    public void MarkAsDied() {
        --currentLives;
        livesLabel.text = "Lives: " + currentLives;
    }

    private void Awake() {
        instance = this;

        Default();
        RefreshLabels();
    }

	private void Start() {
        Restart();
    }

    public bool HasEnoughLives => currentLives > 0;

    public void Restart() {
        Debug.Assert(HasEnoughLives, "Not enough lives to restart the game! Check HasEnoughLives() before calling Restart().");

        player.Default();
        ball.Default();

        StartCoroutine(StartGame());
    }

    private void RefreshLabels() {
        scoreLabel.text = "Score: " + currentScore;
        livesLabel.text = "Lives: " + currentLives;
    }

    private void Default() {
        currentScore = 0;
        currentLives = MaxLives;
    }

    private IEnumerator StartGame() {
        getReadyLabel.enabled = true;

        yield return new WaitForSeconds(3f);

        getReadyLabel.enabled = false;
        
        ball.Kick();
    }

    private void Update() {

#if false //debug commands
        if(Input.GetKeyDown(KeyCode.Q)) {
            currentLives = 0;
        } else if(Input.GetKeyDown(KeyCode.W)) {
            currentScore = MaxBricks;
        }
#endif

        if(currentScore == MaxBricks) {
            SceneManager.LoadScene("Win");
        } else if(currentLives == 0) {
            Results.instance.topScore = currentScore;
            SceneManager.LoadScene("Lose");
        }

    }

    private void OnDestroy() {
        instance = null;
    }

}