using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    private float time;
    public GameObject trash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            for (int i = Random.Range(2,5); i >=0; i--)
            {
            Instantiate(trash.transform.GetChild(Random.Range(0,50)).gameObject,new Vector3(94,9,-35),Quaternion.identity);
            }

            time = Random.Range(2.0f, 6.0f);
        }
        time -= Time.deltaTime;
    }
}
