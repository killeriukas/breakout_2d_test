using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopScore : MonoBehaviour {

    public Text Label;

    private void Awake() {
        Label.text += Results.instance.topScore.ToString();
    }
}