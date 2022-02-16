using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceRecorder : MonoBehaviour
{
    private List<int> code = new List<int>{1,2};
    public List<int> playerCode = new List<int>();
    [SerializeField]private DoorController controlledGate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Record(int buttonCode)
    {
        if (playerCode.Count == code.Count)
        {
            playerCode.RemoveAt(0);

        }

        playerCode.Add(buttonCode);
        
        if (playerCode.Count == code.Count)
        {bool same = true;
            for (int i = 0; i < playerCode.Count; i++)
            {
               if(playerCode[i] != code[i])
                {
                    same = false;
                }
            }
            if (same)
            {
                controlledGate.TurnOn();
            }

        }
    }
}
