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

    public bool HasEnoughLives => currentLives > 0;

    public void MarkAsScored() {
        ++currentScore;
        scoreLabel.text = "Score: " + currentScore;

        CheckWinCondition();
    }

    public void MarkAsDied() {
        --currentLives;
        livesLabel.text = "Lives: " + currentLives;

        CheckLoseCondition();
    }

    private void Awake() {
        instance = this;

        Default();
        RefreshLabels();
    }

	private void Start() {
        Restart();
    }

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

    private void CheckWinCondition() {
        if(currentScore == MaxBricks) {
            SceneManager.LoadScene("Win");
        }
    }

    private void CheckLoseCondition() {
        if(0 == currentLives) {
            Results.instance.topScore = currentScore;
            SceneManager.LoadScene("Lose");
        }
    }

#if true //debug commands

    private void Update() {


        if(Input.GetKeyDown(KeyCode.Q)) {
            currentLives = 0;
            CheckLoseCondition();
        } else if(Input.GetKeyDown(KeyCode.W)) {
            currentScore = MaxBricks;
            CheckWinCondition();
        }

    }

#endif

    private void OnDestroy() {
        instance = null;
    }

}