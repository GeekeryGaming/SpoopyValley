using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Vector3 playerPos;
    public Transform destination;
    public Transform hazard;
    private Rigidbody pRB;

    // Start is called before the first frame update
    void Start(){
        pRB = GetComponent<Rigidbody>();
        playerPos = transform.position;
        }

    // Update is called once per frame
    void Update(){
        //transform.position = playerPos;

        if (Input.GetKey(KeyCode.W))
            {
            pRB.AddForce(Vector3.left*10);
            //playerPos += Vector3.left;
           // playerPos -= transform.right;
        }
        
        if (playerPos.x == destination.position.x &&
            playerPos.z == destination.position.z){
            playerPos += transform.up;
        }
        if (playerPos.x == hazard.position.x &&
            playerPos.z == hazard.position.z)
        {
            playerPos -= transform.up;
        }


        transform.position = playerPos;
    }

}

