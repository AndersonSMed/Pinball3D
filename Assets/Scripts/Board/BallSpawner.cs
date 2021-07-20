using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : AbstractInteractibleElement {

    [SerializeField]
    private GameObject ballPrefab;

    private Transform spawnPosition;

    private int previousLeftBalls;

    private Vector3 CopyTransform() {
        return new Vector3(
            this.spawnPosition.position.x,
            this.spawnPosition.position.y,
            this.spawnPosition.position.z
        );
    }

    private void SpawnBallObject() {
        Instantiate(this.ballPrefab, this.CopyTransform(), Quaternion.identity);
    }

    void Start() {
        this.spawnPosition = gameObject.GetComponent<Transform>();
    }

    public override void CustomUpdate() {
        if (this.previousLeftBalls != GameManager.Instance.leftBalls) {
            this.previousLeftBalls = GameManager.Instance.leftBalls;
            this.SpawnBallObject();
        }
    }

    public override void CustomFixedUpdate() {}
}
