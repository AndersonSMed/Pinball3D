using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance;

    public float playerScore { get; private set; }

    public int leftBalls { get; private set; }

    public bool isGameStarted { get; private set; }

    public bool isGameEnded { get; private set; }

    public bool isGameRuning {
        get {
            return isGameStarted && !isGameEnded;
        }
    }

    public bool isGameInStartMenu {
        get {
            return !isGameStarted && !isGameEnded;
        }
    }

    public bool isGameInEndMenu {
        get {
            return isGameStarted && isGameEnded;
        }
    }

    public static GameManager Instance { get { return instance; } }

    // Private Actions
    private void RestartGameValues() {
        this.playerScore = 0f;
        this.leftBalls = 3;
        this.isGameStarted = false;
        this.isGameEnded = false;
    }

    private void PreGameUpdate() {
        if (Input.anyKey) {
            this.isGameStarted = true;
        }
    }

    private void InGameUpdate() {}

    private void PostGameUpdate() {
        if (Input.anyKey) {
              this.RestartGameValues();
              this.isGameStarted = true;
              this.isGameEnded = false;
        }
    }

    // Public Actions
    public void RestartGame() {
        this.RestartGameValues();
    }

    public void IncreaseplayerScore(float pontuation) {
        this.playerScore += pontuation;
    }

    public void DecreaseLeftBalls() {
        this.leftBalls -= 1;
        if (this.leftBalls == 0) {
            this.isGameEnded = true;
        }
    }

    // MonoBehaviour Methods
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(instance);
        } else {
            instance = this;
        }
    }

    void Start() {
        this.RestartGameValues();
    }

    void Update() {
        if (this.isGameInStartMenu) {
            this.PreGameUpdate();
        }
        if (this.isGameRuning) {
            this.InGameUpdate();
        }
        if (this.isGameInEndMenu) {
            this.PostGameUpdate();
        }
    }
}
