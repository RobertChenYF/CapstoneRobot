using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingWall : MonoBehaviour
{
    [SerializeField]private List<GameObject> rotateObject;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject a in rotateObject)
        {
            a.transform.Rotate(new Vector3(0,1,0),500*Time.deltaTime);
        }

        gameObject.transform.Translate(transform.forward* speed* Time.deltaTime, Space.Self);
    }
}
