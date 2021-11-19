using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossAI : MonoBehaviour
{
    [SerializeField] private GameObject Bomb;
    [SerializeField] private Transform BombDropTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bomb,BombDropTransform.position,Quaternion.identity);
        }
    }
}
