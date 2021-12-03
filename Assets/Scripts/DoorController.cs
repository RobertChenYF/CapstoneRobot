using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private bool open;
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private bool On;
    [SerializeField] private Renderer doorRenderer;
    [SerializeField] private GameObject Scanner;
    [SerializeField] private MeshRenderer ScannerwaveRenderer;
    [SerializeField] private Color TransparentGreen;
    [SerializeField] private Color TransparentBlue;
    // Start is called before the first frame update
    void Start()
    {
        if (On)
        {
            doorRenderer.materials[1].EnableKeyword("_EMISSION");
            doorRenderer.materials[1].SetColor("_EmissionColor", Color.green*3.0f);
            if (Scanner != null)
            {
                Scanner.SetActive(true);
            }
            
        }
        else
        {
            doorRenderer.materials[1].SetColor("_EmissionColor", Color.black);
            if (Scanner != null)
            {
                Scanner.SetActive(false);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        if (On)
        {
        doorAnimator.SetTrigger("Open");
        open = true;
        }
        
    }

    public void CloseDoor()
    {
        if (On)
        {
            doorAnimator.SetTrigger("Close");
            open = false;
        }
        
    }
    public void TurnOn()
    {
        doorRenderer.materials[1].EnableKeyword("_EMISSION");
        doorRenderer.materials[1].SetColor("_EmissionColor", Color.green*3.0f);
        if (Scanner != null)
        {
            Scanner.SetActive(true);
        }
        On = true;
    }

    public void ScannerDetect()
    {
        ScannerwaveRenderer.material.SetColor("_Color", TransparentGreen);
    }

    public void ScannerUndetect()
    {
        ScannerwaveRenderer.material.SetColor("_Color", TransparentBlue);
    }
}
