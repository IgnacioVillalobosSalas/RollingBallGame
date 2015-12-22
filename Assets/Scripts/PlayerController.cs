using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 movement;
    public float Speed = 1;
    private int CollectableItemsCount;

    public Text scoretext;


    void Start() {
        //Component Rigidbody from the object 
        rb = GetComponent<Rigidbody>();
        CollectableItemsCount=0;

        SetScoreText();
    }
    //FixedUpdate is called before performing any physics calculations
    void FixedUpdate() {

        /*From keyboard
        movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        */

        /*From accelerometer*/
        rb.AddForce(new Vector3(Input.acceleration.x,Input.acceleration.z,Input.acceleration.y), ForceMode.Acceleration);



    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("CItems")) {
        other.gameObject.SetActive(false);
        CollectableItemsCount++;
        SetScoreText();
        }

    }
    void SetScoreText() {

        scoretext.text = "Score : " + CollectableItemsCount;
    }
}
