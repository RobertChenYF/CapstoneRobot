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

    [HideInInspector]public bool grab = false;

    [SerializeField]private GrabController grabController;
    [SerializeField] private SimpleCarController carController;

    //private string CAMERA_INPUT_AXIS = "camera";
    

    public Transform RotateGrap;
    public HingeJoint grap1;
    public HingeJoint grap2;

    private JointSpring grap1Spring;
    private JointSpring grap2Spring;

    [SerializeField]private GameObject CameraDisplay;
    [SerializeField] private MeshRenderer arm1JointRenderer;
    [SerializeField] private MeshRenderer arm2JointRenderer;

    [SerializeField] private GameObject arm1;
    [SerializeField] private GameObject arm2;
    [SerializeField] private Transform arm1Stick;
    [SerializeField] private Transform arm2Stick;
    private Quaternion arm1rot;
    private Vector3 arm1Pos;
    // Start is called before the first frame update

    private void Awake()
    {
        Service.robotController = this;
    }

    void Start()
    {
        

        arm1Spring = Arm1.spring;
        arm2Spring = Arm2.spring;
        grap1Spring = grap1.spring;
        grap2Spring = grap2.spring;
        arm1rot = arm1.transform.localRotation;
        arm1Pos = arm1.transform.localPosition;

        
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

    public void SwitchTo1Arm()
    {
        arm1.SetActive(true);
        grabController.gameObject.transform.SetParent(arm1Stick);
        grabController.gameObject.transform.localPosition = new Vector3(0,0,0);
        arm2.SetActive(false);
    }

    public void SwitchTo2Arm()
    {
        arm1.SetActive(true);
        arm1.transform.localPosition = arm1Pos;
        arm1.transform.localRotation = arm1rot;
        arm2.SetActive(true);

        grabController.gameObject.transform.SetParent(arm2Stick);
        grabController.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        
    }

    public void NoArm()
    {
        arm1.SetActive(false);
        arm2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Grap"))
        {
            grabController.myMat.SetColor("_ArrowColor", grabController.GrabColor);
            grabController.grabSound.Play();

            if (grabController.grabObject != null && grab == false)
            {
                grab = true;
                //grabController.grabObject.transform.SetParent(grabController.gameObject.transform);
                if (grabController.grabObject.GetComponent<FixedJoint>() == null)
                {
                    grabController.grabObject.AddComponent<FixedJoint>();
               }
                
                grabController.grabObject.GetComponent<FixedJoint>().connectedBody = grabController.gameObject.GetComponent<Rigidbody>();
                grabController.myMat.SetColor("_ArrowColor", grabController.GrabColor*3.5f);
                //Set gravity to false while holding it
                grabController.grabObject.GetComponent<Rigidbody>().useGravity = false;
               // grabController.grabObject.GetComponent<Rigidbody>().isKinematic = true;
            }
            else if (grab == true)
            {
                grab = false;
                if (grabController.grabObject.GetComponent<FixedJoint>() != null)
                {
                    grabController.grabObject.GetComponent<Rigidbody>().useGravity = true;
               //     grabController.grabObject.GetComponent<Rigidbody>().isKinematic = false ;
                    Destroy(grabController.grabObject.GetComponent<FixedJoint>());
                }
                grabController.myMat.SetColor("_ArrowColor", grabController.StaticColor*3.5f);
            }
        }
        if (Input.GetButtonUp("Grap") && grabController.grabObject == null)
        {
            grabController.grabSound.Stop();
        }
        if (Input.GetAxis(Grap_Axis) == 0)
        {
            if (grab == false && grabController.grabObject == null)
            {
                grabController.myMat.SetColor("_ArrowColor", grabController.StaticColor);
            }
        }


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
        if (Input.GetAxis(ARM1_INPUT_AXIS) > 0.1f)
        {
            arm1JointRenderer.materials[1].SetColor("_ArrowColor",carController.ColorGreen * (1f + Mathf.Abs(Input.GetAxis(ARM1_INPUT_AXIS)) * 3.0f));
        }
        else if (Input.GetAxis(ARM1_INPUT_AXIS) < -0.1f)
        {
            arm1JointRenderer.materials[1].SetColor("_ArrowColor", carController.ColorRed * (1f + Mathf.Abs(Input.GetAxis(ARM1_INPUT_AXIS)) * 3.0f));
        }
        else
        {
            arm1JointRenderer.materials[1].SetColor("_ArrowColor", Color.gray);
        }
        arm2Spring.targetPosition = arm2Spring.targetPosition + Input.GetAxis(ARM2_INPUT_AXIS) * armRotateSpeed * Time.deltaTime;
        arm2Spring.targetPosition = Mathf.Clamp(arm2Spring.targetPosition, Arm2PosMin, Arm2PosMax);
        Arm2.spring = arm2Spring;

        if (Input.GetAxis(ARM2_INPUT_AXIS) > 0.1f)
        {
            arm2JointRenderer.materials[1].SetColor("_ArrowColor", carController.ColorGreen * (1f + Mathf.Abs(Input.GetAxis(ARM2_INPUT_AXIS)) * 3.0f));
        }
        else if (Input.GetAxis(ARM2_INPUT_AXIS) < -0.1f)
        {
            arm2JointRenderer.materials[1].SetColor("_ArrowColor", carController.ColorRed * (1f + Mathf.Abs(Input.GetAxis(ARM2_INPUT_AXIS)) * 3.0f));
        }
        else
        {
            arm2JointRenderer.materials[1].SetColor("_ArrowColor", Color.gray);
        }
    }
}

