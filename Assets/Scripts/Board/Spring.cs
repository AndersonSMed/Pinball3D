using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : AbstractInteractibleElement {
    [SerializeField]
    private Transform maxTransform;

    [SerializeField]
    private Transform selfTransform;
    
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float distanceAccumulator;

    [SerializeField]
    private KeyCode triggerKey;

    private Vector3 initialPosition;

    private float greatestDistance = 0f;

    void Start() {
        this.initialPosition = selfTransform.position;
    }

    void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
        Rigidbody otherRigidbody =
            contact.otherCollider.gameObject.GetComponent<Rigidbody>();
        
        float speed = this.greatestDistance * this.distanceAccumulator;

        otherRigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
        this.greatestDistance = 0f;
    }

    public override void CustomUpdate() {}

    public override void CustomFixedUpdate() {
        if(Input.GetKey("space")) {
            this.selfTransform.position = Vector3.MoveTowards(
                this.selfTransform.position,
                this.maxTransform.position,
                this.movementSpeed * Time.deltaTime
            );
        } else {
          float distance = Vector3.Distance(this.selfTransform.position, this.initialPosition);
          float speed = (this.distanceAccumulator * distance) + this.movementSpeed;

          if (distance >= this.greatestDistance) {
            this.greatestDistance = distance;
          } else if (distance == 0f) {
            this.greatestDistance = 0f;
          }

          this.selfTransform.position = Vector3.MoveTowards(
              this.selfTransform.position,
              this.initialPosition,
              speed * Time.deltaTime
          );
        }
    }
}
