using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAxisMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;
    public float notLockedAxisX = 1f;
    public float notLockedAxisZ = 0f;
    public float playerForceForw;
    public float playerForceBack;
    private bool jumped = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Vertical");
        if (xValue > 0)
        {
            Debug.Log("ide X");
            rb.AddForce(-xValue * playerForceForw * Time.deltaTime * notLockedAxisX, 0, xValue * playerForceForw * Time.deltaTime * notLockedAxisZ);//zValue * playerForceSide * Time.deltaTime
            //NOTE: We could use cam.transform.Translate(x, y, z); if we wanted to just change the position of the player instead of adding physical force
        }
        else
        {
            rb.AddForce(-xValue * playerForceBack * Time.deltaTime* notLockedAxisX, 0, xValue * playerForceBack * Time.deltaTime * notLockedAxisZ);
        }

        if (Input.GetKey("e") && !jumped)
        {
            if(notLockedAxisX == 1) {
                notLockedAxisX = 0f;
                notLockedAxisZ = 1f;
            }
            else {
                notLockedAxisZ = 0f;
                notLockedAxisX = 1f;
            }
        }
        // if (shouldRotate && cam.transform.eulerAngles.y % 360 - prevAngle < 90 && cam.transform.eulerAngles.y % 360 - prevAngle >= 0)
        // {
        //     cam.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        //     transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        // }
        // else if (shouldRotate)
        // {
        //     if (cam.transform.eulerAngles.y > prevAngle)
        //     {
        //         cam.transform.Rotate(0, -(cam.transform.eulerAngles.y - prevAngle) % 90, 0);
        //         transform.Rotate(0, -(cam.transform.eulerAngles.y - prevAngle) % 90, 0);
        //     }
        //     else
        //     {
        //         cam.transform.Rotate(0, -cam.transform.eulerAngles.y % 90, 0);
        //         transform.Rotate(0, -cam.transform.eulerAngles.y % 90, 0);
        //         Debug.Log(prevAngle - cam.transform.eulerAngles.y);

        //     }
        //     shouldRotate = false;
        //     jumped = false;
        // }
    }
}
