using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReference : MonoBehaviour
{

    public GameObject ScifiFloor;
    [ExecuteInEditMode]
    // Start is called before the first frame update
    void Awake()
    {
        Service.gameReference = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class Service 
{
    
    public static GameReference gameReference;
    public static RobotController robotController;

}
