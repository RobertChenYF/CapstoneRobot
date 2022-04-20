using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class SimpleCarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    [SerializeField] private AnimationCurve AxisToSpeed;
    [SerializeField] private GameObject leftArrow,rightArrow;
    [SerializeField] public Color ColorGreen;
    [SerializeField] public Color ColorRed;
    [SerializeField] private bool hasArrow;
    [SerializeField] private AudioSource robotSound;
    [SerializeField] private AudioClip moveForward;
    [SerializeField] private AudioClip moveBackward;



    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        
        /*float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
           // ApplyLocalPositionToVisuals(axleInfo.leftWheel);
           // ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
        */
        foreach (AxleInfo axleInfo in axleInfos)
        {
            //float motor = maxMotorTorque * Input.GetAxis("Vertical");

            float leftTank = Input.GetAxis("leftTank");
            float rightTank = Input.GetAxis("rightTank");

            if (hasArrow)
            {
                if (Mathf.Abs(leftTank) < 0.1f)
                {
                    leftArrow.SetActive(false);
                }
                else
                {
                    leftArrow.SetActive(true);
                    if (Mathf.Sign(leftTank) == -1)
                    {
                        leftArrow.GetComponent<SpriteRenderer>().flipX = true;
                        leftArrow.GetComponent<SpriteRenderer>().material.SetColor("_ArrowColor", ColorRed * (1f + Mathf.Abs(leftTank) * 3.0f));
                    }
                    else
                    {
                        leftArrow.GetComponent<SpriteRenderer>().flipX = false;
                        leftArrow.GetComponent<SpriteRenderer>().material.SetColor("_ArrowColor", ColorGreen * (1f + Mathf.Abs(leftTank) * 3.0f));
                    }
                }

                if (Mathf.Abs(rightTank) < 0.1f)
                {
                    rightArrow.SetActive(false);
                }
                else
                {
                    rightArrow.SetActive(true);
                    if (Mathf.Sign(rightTank) == -1)
                    {
                        rightArrow.GetComponent<SpriteRenderer>().flipX = true;
                        rightArrow.GetComponent<SpriteRenderer>().material.SetColor("_ArrowColor", ColorRed * (1f + Mathf.Abs(rightTank) * 3.0f));
                    }
                    else
                    {
                        rightArrow.GetComponent<SpriteRenderer>().flipX = false;
                        rightArrow.GetComponent<SpriteRenderer>().material.SetColor("_ArrowColor", ColorGreen * (1f + Mathf.Abs(rightTank) * 3.0f));
                    }
                }

                if (Mathf.Abs(rightTank) + Mathf.Abs(leftTank) > 0.2f)
                {
                    robotSound.Play();
                    robotSound.volume = ((Mathf.Abs(rightTank) + Mathf.Abs(leftTank)) * 0.5f + 0.5f);
                }
                else
                {
                    robotSound.Stop();
                }
            }
            

            if (axleInfo.motor)
            {

                axleInfo.leftWheel.motorTorque = AxisToSpeed.Evaluate(Mathf.Abs(leftTank))*Mathf.Sign(leftTank) * maxMotorTorque;
 
                axleInfo.rightWheel.motorTorque = AxisToSpeed.Evaluate(Mathf.Abs(rightTank)) * Mathf.Sign(rightTank) * maxMotorTorque;

                
                
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }

    }
}