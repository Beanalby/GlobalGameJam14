﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float speed = 5;
    private float turnSpeed = 75;
    private float throwStrength = 5f;

    private WorldControl wc;
    private bool needsCentered = true;

    private bool canControl = true;
    public bool CanControl {
        get { return canControl; }
    }
    private float currentSpeed = 0;
    private Animator animator;

    public void Start() {
        animator = GetComponentInChildren<Animator>();
        wc = GameObject.Find("WorldState").GetComponent<WorldControl>();
    }
    public void Update() {
        HandleMoving();
        if(animator) {
            animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
        }
    }

    void HandleMoving() {
        currentSpeed = 0;
        if (!canControl) {
            return;
        }
        if (wc.showingMenu) {
            needsCentered = true;
            return;
        }
        if (needsCentered) {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) {
                needsCentered = false;
            } else {
                return;
            }
        }
        Vector3 rot = rigidbody.rotation.eulerAngles;
        rot.y += Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
        rigidbody.MoveRotation(Quaternion.Euler(rot));

        if(Input.GetAxis("Vertical") != 0) {
            currentSpeed = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            Vector3 pos = rigidbody.position;
            pos += transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * Time.deltaTime * speed;
            rigidbody.MovePosition(pos);
        }
    }

    public void GotHit(GameObject attacker) {
        Vector3 throwDir = attacker.transform.TransformDirection(Vector3.forward);
        //Vector3 throwDir = attacker.transform.rotation.eulerAngles.normalized;
        throwDir.y = 1;
        rigidbody.velocity = throwDir * throwStrength;
        canControl = false;
    }

    public void OnCollisionEnter(Collision collision) {
        if (!canControl) {
            canControl = true;
        }
    }
}
