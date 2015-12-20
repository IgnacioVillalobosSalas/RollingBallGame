using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 movement;
    public float Speed = 1;


    void Start() {
        //Component Rigidbody from the object 
        rb = GetComponent<Rigidbody>();
    }
    //FixedUpdate is called before performing any physics calculations
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * Speed);
    }
    void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("CItems"))
            other.gameObject.SetActive(false);


    }
}
