using System;
using UnityEngine;

public class JoystickControll : MonoBehaviour
{

    /*
    public Transform topOfJoystick;

    [SerializeField]
    public float forwardBackwardTilt = 0;
    [SerializeField]
    private float sideToSideTilt = 0;

    public float tankSpeed;

    public bool Display;

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(forwardBackwardTilt);
        forwardBackwardTilt = topOfJoystick.rotation.eulerAngles.x;
        if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
        {
            //forwardBackwardTilt = Math.Abs(forwardBackwardTilt - 360);
             
            tankSpeed = Remap(forwardBackwardTilt,290,355,-1.5f,-0.4f);
            //Debug.Log("Backward" + tankSpeed);
            //tankSpeed = -1;
            //Move something using forwardBackwardTilt as speed
        }
        else if (forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
        {
            // Debug.Log("Forward" + forwardBackwardTilt);
            //tankSpeed = 1;
            tankSpeed = Remap(forwardBackwardTilt, 5, 74, 0.4f, 1.5f);
            //Debug.Log("forward" + tankSpeed);
            //Move something using forwardBackwardTilt as speed
        }
        else
        {
            tankSpeed = 0;
        }

        sideToSideTilt = topOfJoystick.rotation.eulerAngles.z;
        if (sideToSideTilt < 355 && sideToSideTilt > 290)
        {
            sideToSideTilt = Math.Abs(sideToSideTilt - 360);
            //Debug.Log("Right" + sideToSideTilt);
            //Turn something using sideToSideTilt as speed
        }
        else if (sideToSideTilt > 5 && sideToSideTilt < 74)
        {
            //Debug.Log("Left" + sideToSideTilt);
            //Turn something using sideToSideTilt as speed
        }
        if (Display)
        {
            Debug.Log(transform.localRotation.eulerAngles);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            if (other.gameObject.name.Equals("CustomHandLeft")&& (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.8f))
            {
                //Vector3 lookAtPosition = other.transform.position;
                //lookAtPosition.y = transform.position.y;
                //lookAtPosition.z = transform.position.z;
                transform.LookAt(other.transform.position, transform.up);

                forwardBackwardTilt = topOfJoystick.rotation.eulerAngles.x;
                OVRInput.SetControllerVibration(0.1f, 0.2f, OVRInput.Controller.LTouch);
                //Quaternion rotation = Quaternion.LookRotation(other.transform.position, Vector3.up);
                //transform.rotation = rotation;
                if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -180, -180);
                }
                else if(forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, 0);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(270, 0, 0);
                }
                //
            }
            else if (other.gameObject.name.Equals("CustomHandLeft") && (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) <= 0.8f))
            {
                OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);


            }
            if (other.gameObject.name.Equals("CustomHandRight") && (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.8f))
            {
                OVRInput.SetControllerVibration(0.1f, 0.2f, OVRInput.Controller.RTouch);
                transform.LookAt(other.transform.position, transform.up);

                forwardBackwardTilt = topOfJoystick.rotation.eulerAngles.x;
                
                //Quaternion rotation = Quaternion.LookRotation(other.transform.position, Vector3.up);
                //transform.rotation = rotation;
                if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -180, -180);
                }
                else if (forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, 0);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(270, 0, 0);
                }
                //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.y);
            }
            else if (other.gameObject.name.Equals("CustomHandRight") && (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) <= 0.8f))
            {
                OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            if (other.gameObject.name.Equals("CustomHandLeft"))
            {

                OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);
               
            }
            if (other.gameObject.name.Equals("CustomHandRight"))
            {
                OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
               
            }

        }
    }

    public float Remap(float from, float fromMin, float fromMax, float toMin, float toMax)
    {
        var fromAbs = from - fromMin;
        var fromMaxAbs = fromMax - fromMin;

        var normal = fromAbs / fromMaxAbs;

        var toMaxAbs = toMax - toMin;
        var toAbs = toMaxAbs * normal;

        var to = toAbs + toMin;

        return to;
    }
    */
}