using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class NewButton : MonoBehaviour
{
    public UnityEvent onPressed;
    public UnityEvent onReleased;

    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool isPressed;
    private Vector3 startPos;
    [SerializeField]private ConfigurableJoint configurableJoint;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        Debug.Log(startPos);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetValue() + threshold);
        if (!isPressed && GetValue() + threshold >=0.5f)
        {
            Pressed();
        }
        if (isPressed && GetValue() - threshold <=0.3f)
        {
            Released();
        }
    }

    private float GetValue()
    {
        //Debug.Log(transform.localPosition);
        float var = Vector3.Distance(startPos,transform.localPosition)/configurableJoint.linearLimit.limit;
        //Debug.Log(Vector3.Distance(startPos,transform.localPosition));
        if (Mathf.Abs(var) < deadZone)
        {
            var = 0;
        }

        return Mathf.Clamp(var, -1.0f, 1.0f);

    }
    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");

    }
    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();

    }
}
