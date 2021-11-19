using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField]private GameObject explosionEffect;
    [SerializeField] private float explosionCountDown;
    private Material bombMat;
    [SerializeField] float bombRadius;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        bombMat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>explosionCountDown)
        {

            Explode();
        }
        timer += Time.deltaTime;
        GetComponent<MeshRenderer>().materials[1].SetFloat("_intensity",timer);
    }

    void Explode()
    {
        Instantiate(explosionEffect,gameObject.transform.position,Quaternion.identity);
        CameraEffectController.instance.cameraShake(3.0f,0.5f);
        ExplosionDamage(transform.position,bombRadius);
        Destroy(gameObject);
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Battery"))
            {

                Destroy(hitCollider.gameObject);
                //destroy battery
            }
        }
    }
}
