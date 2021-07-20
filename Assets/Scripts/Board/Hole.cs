using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

  private void OnCollisionEnter(Collision collision) {
      ContactPoint contact = collision.contacts[0];
      Destroy(contact.otherCollider.gameObject);
      GameManager.Instance.DecreaseLeftBalls();
  }
}
