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

    [SerializeField] private GameObject[] indicateLight;
    
    // Start is called before the first frame update
    void Start()
    {
        if (On&&doorRenderer != null)
        {
            doorRenderer.materials[1].EnableKeyword("_EMISSION");
            doorRenderer.materials[1].SetColor("_EmissionColor", Color.green*3.0f);
            if (Scanner != null)
            {
                Scanner.SetActive(true);
            }
            
        }
        else if(doorRenderer != null)
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
        doorAnimator.SetBool("Open",true);
        open = true;

        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        }
        
    }

    public void CloseDoor()
    {
        if (On)
        {
            doorAnimator.SetBool("Open", false);
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
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

    public void TrippleGateEnter(int scannerCode)
    {
        IndicateLightColorChange(indicateLight[scannerCode], Color.green);

        bool open = true;
        
        for (int i = 0; i < 3; i++)
        {
            if (indicateLight[i].GetComponent<MeshRenderer>().materials[1].GetColor("_Color") != Color.green)
            {
                open = false;
                break;
            }
        }
        

        if (open)
        {
            OpenDoor();
        }
    }

    public void TrippleGateExit(int scannerCode)
    {
        IndicateLightColorChange(indicateLight[scannerCode], Color.red);
    }

    public void IndicateLightColorChange(GameObject light,Color color)
    {
        Debug.Log("change light");
        light.GetComponent<MeshRenderer>().materials[1].SetColor("_Color",color);
        light.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", color*1.5f);
        light.transform.GetChild(0).gameObject.GetComponent<Light>().color = color;
    }
}
