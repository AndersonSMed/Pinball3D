using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteractibleElement : MonoBehaviour {
    public abstract void CustomUpdate();
    
    public abstract void CustomFixedUpdate();

    void Update() {
      if (GameManager.Instance.isGameRuning) {
        this.CustomUpdate();
      }
    }

    void FixedUpdate() {
      if (GameManager.Instance.isGameRuning) {
        this.CustomFixedUpdate();
      }
    }
}
