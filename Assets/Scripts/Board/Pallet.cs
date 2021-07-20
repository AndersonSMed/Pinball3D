using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet : AbstractInteractibleElement { 
    [SerializeField]
    private KeyCode rotationTriggerKey;

    [SerializeField]
    private float palletSpeed = 500f;

    [SerializeField]
    private HingeJoint hinge;

    private void HandleRotation() {
        var motor = this.hinge.motor;
        
        float targetVelocity;

        if (Input.GetKey(this.rotationTriggerKey)) {
            targetVelocity = -1 * palletSpeed;
        } else {
            targetVelocity = palletSpeed;
        }

        if (motor.targetVelocity != targetVelocity) {
          motor.targetVelocity = targetVelocity;
          motor.force = palletSpeed;
          this.hinge.motor = motor;
        }
    }

    public override void CustomUpdate() {
        this.HandleRotation();
    }

    public override void CustomFixedUpdate() {}
}
