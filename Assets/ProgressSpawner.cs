using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ProgressSpawner : MonoBehaviour
{
    [SerializeField]private GameObject[] SpawnPos;
    public GameObject car;
    public BeginGame beginGame;
    public float initializeTime = 0;
    public static int positionCode;
    // Start is called before the first frame update

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ProgressManager");
        
        if (objs.Length > 1)
        {
            /*
            if (objs[0].GetComponent<ProgressSpawner>().initializeTime > objs[1].GetComponent<ProgressSpawner>().initializeTime)
            {
                Destroy(objs[0]);
            }
            else
            {
                Destroy(objs[1]);
            }
            */

           Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        car = GameObject.Find("car_root");
        beginGame = GameObject.Find("press to start").GetComponent<BeginGame>();
    }

    void spawn()
    {
        Debug.Log("restart");
        car = Service.Robot;
        beginGame = Service.beginGame;
        Debug.Log(Service.Robot);
        Debug.Log(positionCode);

        if (positionCode >= 0)
        {
        Service.Robot.transform.position = SpawnPos[positionCode].transform.position;
        beginGame.JustBegin();
        if (positionCode == 1 || positionCode == 2)
        {
            Service.robotController.SwitchTo1Arm();
        }
        else if (positionCode == 3 || positionCode == 4)
        {
            Service.robotController.SwitchTo2Arm();
        }
        }

    }

    public void setPositionCode(int a)
    {
        
        positionCode = a;
        Debug.Log("set to " + ProgressSpawner.positionCode);
    }

    // Update is called once per frame
    void Update()
    {
        initializeTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene(0);

            Invoke("spawn", 0.1f);
        }



        


        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Service.Robot.transform.position = SpawnPos[0].transform.position;
            Service.beginGame.JustBegin();
            positionCode = 0;
            Service.robotController.NoArm();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            car.transform.position = SpawnPos[1].transform.position;
            beginGame.JustBegin();
            positionCode = 1;
            Service.robotController.SwitchTo1Arm();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            car.transform.position = SpawnPos[2].transform.position;
            beginGame.JustBegin();
            positionCode = 2;
            Service.robotController.SwitchTo1Arm();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            car.transform.position = SpawnPos[3].transform.position;
            beginGame.JustBegin();
            positionCode = 3;
            Service.robotController.SwitchTo2Arm();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            car.transform.position = SpawnPos[4].transform.position;
            beginGame.JustBegin();
            positionCode = 4;
            Service.robotController.SwitchTo2Arm();
        }

    }
}
