using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex;
    public HingeJoint Arm1;
    
    public HingeJoint Arm2;
    private JointSpring arm1Spring;
    private JointSpring arm2Spring;

    public float Arm1PosMin;
    public float Arm1PosMax;

    public float Arm2PosMin;
    public float Arm2PosMax;

    public float grap1PosMin;
    public float grap1PosMax;

    public float armRotateSpeed;
    public float grapRotateSpeed;
    public float grapCloseSpeed;

    private string ARM1_INPUT_AXIS = "arm1Axis";
    private string ARM2_INPUT_AXIS = "arm2Axis";
    private string ROTATE_GRAP_AXIS = "rotateGrap";
    private string Grap_Axis = "Grap";


    //private string CAMERA_INPUT_AXIS = "camera";
    

    public Transform RotateGrap;
    public HingeJoint grap1;
    public HingeJoint grap2;

    private JointSpring grap1Spring;
    private JointSpring grap2Spring;

    [SerializeField]private GameObject CameraDisplay;
    // Start is called before the first frame update
    void Start()
    {
        

        arm1Spring = Arm1.spring;
        arm2Spring = Arm2.spring;
        grap1Spring = grap1.spring;
        grap2Spring = grap2.spring;
        
        /*currentCameraIndex = 0;
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }


        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C)|| Input.GetKeyDown("joystick button 6"))
        {
            

            if (CameraDisplay.activeSelf == false)
            {
                CameraDisplay.SetActive(true);
            }
            else if (currentCameraIndex < cameras.Length-1)
            {
                currentCameraIndex++;
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                cameras[currentCameraIndex].gameObject.SetActive(true);

            }
            else
            {
                cameras[currentCameraIndex].gameObject.SetActive(false);
                
                
                currentCameraIndex = 0;
                cameras[currentCameraIndex].gameObject.SetActive(true);
                CameraDisplay.SetActive(false);

            }
        }

        grap1Spring.targetPosition = grap1Spring.targetPosition + Input.GetAxis(Grap_Axis) * grapCloseSpeed * Time.deltaTime;
        grap1Spring.targetPosition = Mathf.Clamp(grap1Spring.targetPosition, grap1PosMin, grap1PosMax);
        grap1.spring = grap1Spring;

        grap2Spring.targetPosition = grap2Spring.targetPosition + Input.GetAxis(Grap_Axis) * grapCloseSpeed * Time.deltaTime;
        grap2Spring.targetPosition = Mathf.Clamp(grap2Spring.targetPosition, grap1PosMin, grap1PosMax);
        grap2.spring = grap2Spring;

        RotateGrap.Rotate(new Vector3(0,0,Input.GetAxis(ROTATE_GRAP_AXIS)*grapRotateSpeed*Time.deltaTime),Space.Self);
        
        arm1Spring.targetPosition = arm1Spring.targetPosition + Input.GetAxis(ARM1_INPUT_AXIS) * armRotateSpeed * Time.deltaTime;
        arm1Spring.targetPosition = Mathf.Clamp(arm1Spring.targetPosition, Arm1PosMin,Arm1PosMax);
        Arm1.spring = arm1Spring;

        arm2Spring.targetPosition = arm2Spring.targetPosition + Input.GetAxis(ARM2_INPUT_AXIS) * armRotateSpeed * Time.deltaTime;
        arm2Spring.targetPosition = Mathf.Clamp(arm2Spring.targetPosition, Arm2PosMin, Arm2PosMax);
        Arm2.spring = arm2Spring;
    }
}

