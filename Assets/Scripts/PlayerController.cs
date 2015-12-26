using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 movement;
    public float Speed = 1;
    private int CollectableItemsCount;
    public int WinScore;
    public Text scoretext;
    public Text ResultText;


    void Start() {
        //Component Rigidbody from the object 
        rb = GetComponent<Rigidbody>();
        CollectableItemsCount=0;
        SetScoreText();
    }
    void Update() {

        if (WinScore.Equals(CollectableItemsCount)) {
            //You win !!!!
            ResultText.text = "YOU WIN!!!!!!";
            
        }
        if (rb.transform.position.y < -10) {
            // You fall!! and lose :(
            ResultText.text = "YOU LOSE :(";
            
        }

    }
    //FixedUpdate is called before performing any physics calculations
    void FixedUpdate() {


        //input for keyboard for testing in editor
    #if UNITY_EDITOR
        movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        rb.AddForce(movement, ForceMode.Acceleration);
    #endif

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
