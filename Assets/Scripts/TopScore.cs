using TMPro;
using UnityEngine;

public class TopScore : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI topScoreLabel;

    private void Awake() {
        topScoreLabel.text = "Top score: " + Results.instance.topScore;
    }

}