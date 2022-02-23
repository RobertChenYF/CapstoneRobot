using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour

{
    public GameObject grabObject = null;
    public RobotController robotController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grab"))
        {
            Debug.Log("grab");
            grabObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == grabObject)
        {
            if (grabObject.GetComponent<FixedJoint>() != null)
            {
                Destroy(grabObject.GetComponent<FixedJoint>());
            }
            
            grabObject = null;
            robotController.grab = false;
        }
    }
}
