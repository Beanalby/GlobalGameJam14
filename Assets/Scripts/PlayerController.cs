using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float speed = 5;
    private float turnSpeed = 75;

    private WorldControl wc;

    private bool needsCentered = false;

    public void Start() {
        wc = GameObject.Find("WorldState").GetComponent<WorldControl>();
    }
    public void Update() {
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
            Vector3 pos = rigidbody.position;
            //Debug.Log("Transformed is " + transform.TransformDirection(Vector3.forward)
            //    + ", doing " + (transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * speed));
            pos += transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * Time.deltaTime * speed;
            rigidbody.MovePosition(pos);
        }
    }
}
