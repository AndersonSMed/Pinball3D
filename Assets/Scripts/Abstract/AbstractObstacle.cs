using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractObstacle : MonoBehaviour {
    [SerializeField]
    private float obstacleScore = 0f;

    protected void IncreasePlayerScore() {
      GameManager.Instance.IncreaseplayerScore(this.obstacleScore);
    }

    public abstract void HandleContactWithBall(GameObject ballGameObject);

    private void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
        this.HandleContactWithBall(contact.otherCollider.gameObject);
    }
}
