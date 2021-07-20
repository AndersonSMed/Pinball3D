using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderObstacle : AbstractObstacle {
    [SerializeField]
    private float knockbackForce = 0f;

    private void KnockbackElement(Vector3 elementPosition, Rigidbody elementRigidbody) {
        if (elementRigidbody != null) {
            Vector3 direction = elementPosition - transform.position;

            elementRigidbody.AddForce(direction * knockbackForce, ForceMode.Impulse);
        }
    }
    
    public override void HandleContactWithBall(GameObject ballGameObject) {
        this.KnockbackElement(
            ballGameObject.transform.position,
            ballGameObject.GetComponent<Rigidbody>()
        );
        this.IncreasePlayerScore();
    }
}
