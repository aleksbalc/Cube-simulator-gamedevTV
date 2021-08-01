using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementV2 : MonoBehaviour
{
    [SerializeField] float playerForceForw = 1200.0f; //NOTE: [SerializeField] allows you to change the value of the variable in unity
    [SerializeField] float playerForceSide = 700.0f;
    public int jumpCounter = 0;
    public float moveForw = 1f;
    public float prevAngle=0;
    public float currAngle=0;
    public Rigidbody rb;
    private int[] direction = { 1, 0, -1, 0};
    [SerializeField] float playerForceJump = 800.0f;
    private bool jumped = false;
    private void Start() {
        prevAngle = rb.transform.rotation.eulerAngles.y;
    }

    private void Update() {
        float xValue = Input.GetAxis("Vertical");
        float zValue = Input.GetAxis("Horizontal");
        rb.AddForce(xValue * playerForceForw * Time.deltaTime * direction[jumpCounter], 0, xValue * playerForceForw * Time.deltaTime * direction[(jumpCounter+1)%4]);
        rb.AddForce(zValue * playerForceSide * Time.deltaTime * direction[(jumpCounter+1)%4], 0, zValue * playerForceSide * Time.deltaTime * direction[(jumpCounter+2) % 4]);
        if (Input.GetKey("e") && !jumped)
        {
            rb.AddForce(0, playerForceJump, 0);
            jumped = true;
            jumpCounter++;
            jumpCounter%=4;
        }

        else if(!Input.GetKey("e")) jumped = false;;
    }
    

}