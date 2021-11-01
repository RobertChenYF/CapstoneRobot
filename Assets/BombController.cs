using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField]private GameObject explosionEffect;
    [SerializeField] private float explosionCountDown;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>explosionCountDown)
        {

            Explode();
        }
        timer += Time.deltaTime;
    }

    void Explode()
    {
        Instantiate(explosionEffect,gameObject.transform.position,Quaternion.identity);
        CameraEffectController.instance.cameraShake(3.0f,0.5f);
        Destroy(gameObject);
    }
}
