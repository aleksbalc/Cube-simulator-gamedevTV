using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerForceForw = 1000.0f; //NOTE: [SerializeField] allows you to change the value of the variable in unity
    [SerializeField] float playerForceSide = 800.0f;
    [SerializeField] float playerForceBack = 600.0f;
    [SerializeField] float playerForceJump = 300.0f;
    public Rigidbody rb;
    public Transform cam;
    public float rotationSpeed;
    public float prevAngle;
    private bool jumped = false;
    private bool shouldRotate = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I'm moving!");
    }

    // Update is called once per frame
    void Update() //TO-DO: With every jump our plater changes where it's front is
    {
        float xValue = Input.GetAxis("Vertical"); //NOTE: GetAxis("horizontal") returns -1 when you input A, 1 for input D (but it's not instant), 0 for no input. If you press A and D at once, the value stops changing 
        float zValue = -Input.GetAxis("Horizontal"); //NOTE: Input.GetAxis("Vertical") works similarly to the Input.GetAxis("Horizontal") but f("W")=1, f("S")=-1; You can change the letters assigned in Unity
        
        //Debug.Log(Input.GetAxis("Vertical")); 
        if(xValue>0) {
            rb.AddForce(xValue * playerForceForw * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad*transform.eulerAngles.y), 0, 0);//zValue * playerForceSide * Time.deltaTime
            //NOTE: We could use cam.transform.Translate(x, y, z); if we wanted to just change the position of the player instead of adding physical force
        }
        else {
            rb.AddForce(xValue * playerForceBack * Time.deltaTime, 0, zValue * playerForceSide * Time.deltaTime);
        }

        if (Input.GetKey("e") && !jumped)
        {
            prevAngle = cam.transform.eulerAngles.y;
            jumped = true;
            rb.AddForce(0, playerForceJump, 0); // I don't use Time.deltaTime here, because it's a singular action
            Debug.Log(prevAngle);
            shouldRotate = true;
        }
        if (shouldRotate && cam.transform.eulerAngles.y % 360 - prevAngle < 90 && cam.transform.eulerAngles.y % 360 - prevAngle >= 0)
        {
            cam.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        else if (shouldRotate)
        {
            if (cam.transform.eulerAngles.y > prevAngle)
            {
                cam.transform.Rotate(0, -(cam.transform.eulerAngles.y - prevAngle) % 90, 0);
                transform.Rotate(0, -(cam.transform.eulerAngles.y - prevAngle) % 90, 0);
            }
            else
            {
                cam.transform.Rotate(0, -cam.transform.eulerAngles.y % 90, 0);
                transform.Rotate(0, -cam.transform.eulerAngles.y % 90, 0);
                Debug.Log(prevAngle - cam.transform.eulerAngles.y);

            }
            shouldRotate = false;
            jumped = false;
        }
    }
}
