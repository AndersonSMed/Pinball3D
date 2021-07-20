using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
    [SerializeField]
    private GameObject inGamePanel;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text leftBallsText;

    [SerializeField]
    private GameObject preGamePanel;

    [SerializeField]
    private GameObject postGamePanel;

    [SerializeField]
    private Text summaryText;

    private void UpdatePreGamePanel() {
        this.preGamePanel.SetActive(GameManager.Instance.isGameInStartMenu);
    }

    private void UpdateInGamePanel() {
        this.inGamePanel.SetActive(GameManager.Instance.isGameRuning);
        this.scoreText.text = "Score: " + GameManager.Instance.playerScore;
        this.leftBallsText.text = "Left Balls: " + GameManager.Instance.leftBalls;
    }

    private void UpdatePostGamePanel() {
        this.postGamePanel.SetActive(GameManager.Instance.isGameInEndMenu);
        this.summaryText.text = "Your score was: " + GameManager.Instance.playerScore;
    }

    void Update() {
        this.UpdatePreGamePanel();
        this.UpdateInGamePanel();
        this.UpdatePostGamePanel();      
    }
}
