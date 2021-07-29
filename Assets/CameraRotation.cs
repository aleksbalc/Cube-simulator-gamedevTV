using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed;
   public float prevAngle;
   private bool camJumped = false;
   private bool shouldRotate = false;
    public Transform player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = player.rotation;
        
        //float beginningRotation = transform.eulerAngles.y;
        if(Input.GetKey("e") && !camJumped) {
            prevAngle = transform.eulerAngles.y;
            camJumped= true;
            Debug.Log("jump");
            shouldRotate = true;
        }
        //Debug.Log(transform.eulerAngles.y);
        if (shouldRotate && transform.eulerAngles.y % 360 - prevAngle < 90 && transform.eulerAngles.y % 360 - prevAngle >= 0)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        else if (shouldRotate)
        {
            if (transform.eulerAngles.y > prevAngle)
            {
                transform.Rotate(0, -(transform.eulerAngles.y - prevAngle) % 90, 0);
            }
            else
            {
                transform.Rotate(0, -transform.eulerAngles.y % 90, 0);
                Debug.Log(prevAngle -transform.eulerAngles.y);

            }
            shouldRotate = false;
            camJumped = false;
        }
        
    }

}
