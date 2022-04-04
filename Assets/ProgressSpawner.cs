using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressSpawner : MonoBehaviour
{
    [SerializeField]private Transform[] SpawnPos;
    [SerializeField] private GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            car.transform.position = SpawnPos[0].position;
            Service.robotController.NoArm();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            car.transform.position = SpawnPos[1].position;
            Service.robotController.SwitchTo1Arm();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            car.transform.position = SpawnPos[2].position;
            Service.robotController.SwitchTo1Arm();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            car.transform.position = SpawnPos[3].position;
            Service.robotController.SwitchTo2Arm();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            car.transform.position = SpawnPos[4].position;
            Service.robotController.SwitchTo2Arm();
        }

    }
}
