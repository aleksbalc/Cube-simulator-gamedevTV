using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementV2 : MonoBehaviour
{
    [SerializeField] float playerForceForw = 1000.0f; //NOTE: [SerializeField] allows you to change the value of the variable in unity
    public float lockedAxisX = 1f;
    public float lockedAxisZ = 0f;
    public int jumpCounter = 0;
    public float moveForw = 1f;
    public float prevAngle=0;
    public float currAngle=0;
    public Rigidbody rb;
    [SerializeField] float playerForceJump = 300.0f;
    private bool jumped = false;
    private void Start() {
        prevAngle = rb.transform.rotation.eulerAngles.y;
    }

    private void Update() {
        float xValue = Input.GetAxis("Vertical");
        if(jumpCounter >= 2) moveForw = -1f;
        else moveForw = 1f;
        rb.AddForce(xValue * playerForceForw * Time.deltaTime * lockedAxisX * moveForw, 0 , -xValue * playerForceForw * Time.deltaTime * lockedAxisZ * moveForw);

        if (Input.GetKey("e") && !jumped)
        {
            rb.AddForce(0, playerForceJump, 0);
            jumped = true;
            jumpCounter++;
            jumpCounter%=4;
        

            if (lockedAxisX == 1)
            {
                lockedAxisX = 0f;
                lockedAxisZ = 1f;
            }
            else
            {
                lockedAxisZ = 0f;
                lockedAxisX = 1f;
            }
        }

        else if(!Input.GetKey("e")) jumped = false;;
    }
    

}