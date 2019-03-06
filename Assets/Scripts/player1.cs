using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    public float speed;
    private Vector3 playerPos;
    private Rigidbody playerRigidbody;
    public bool floorContact;
    private object playerRigidboy;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigidbody.AddForce(Vector3.left * speed*Time.deltaTime);

        }if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody.AddForce(Vector3.forward * speed*Time.deltaTime);

        }if (Input.GetKey(KeyCode.S))
        {
            playerRigidbody.AddForce(Vector3.right * speed*Time.deltaTime);

        }if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody.AddForce(Vector3.back * speed*Time.deltaTime);
            //playerRigidbody.AddTorque(Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.Space) &&floorContact)
        {
            playerRigidbody.AddForce(Vector3.up * (speed*0.3f) * Time.deltaTime,ForceMode.Impulse);
        }

        if (transform.position.y < -10)
        {
            transform.position = playerPos;
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            floorContact = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            floorContact = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Congratulation Loser");
            text.SetActive(true);
        }
    }
}
