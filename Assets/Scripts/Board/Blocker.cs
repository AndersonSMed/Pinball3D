using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : AbstractInteractibleElement {
    [SerializeField]
    private Collider selfCollider;
    
    [SerializeField]
    private MeshRenderer mesh;

    private int previousLeftBalls;

    private void OnTriggerExit(Collider outerCollider) {
        this.selfCollider.enabled = true;
        this.mesh.enabled = true;
        GameManager.Instance.SetBallInsideBoard();
    }

    public override void CustomUpdate() {
        if (this.previousLeftBalls != GameManager.Instance.leftBalls) {
            this.selfCollider.enabled = false;
            this.mesh.enabled = false;
            this.previousLeftBalls = GameManager.Instance.leftBalls;
        }
    }

    public override void CustomFixedUpdate() {}
}
