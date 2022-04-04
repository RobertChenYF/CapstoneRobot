using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour

{
    public GameObject grabObject = null;
    public RobotController robotController;
    public Color StaticColor;
    public Color TouchColor;
    [HideInInspector]public Material myMat;
    public Color GrabColor;

    // Start is called before the first frame update
    void Start()
    {
        myMat = GetComponent<MeshRenderer>().material;
        GetComponent<MeshRenderer>().material.SetColor("_ArrowColor",StaticColor);
        
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
            GetComponent<MeshRenderer>().material.SetColor("_ArrowColor", TouchColor*3.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == grabObject)
        {
            grabObject.GetComponent<Rigidbody>().useGravity = true;
            if (grabObject.GetComponent<FixedJoint>() != null)
            {
                Destroy(grabObject.GetComponent<FixedJoint>());
            }
            GetComponent<MeshRenderer>().material.SetColor("_ArrowColor", StaticColor);
            grabObject = null;
            robotController.grab = false;
        }
    }
}
