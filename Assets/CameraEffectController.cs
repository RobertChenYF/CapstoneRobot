using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraEffectController : MonoBehaviour
{
    public static CameraEffectController instance;
    [SerializeField]private CinemachineVirtualCamera gameCamera;
    private float shakeTimer = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0)
        {

            shakeTimer -= Time.deltaTime;
        }
        else if (shakeTimer < 0)
        {
            gameCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        }
    }

    public void cameraShake(float intensity, float duration)
    {
        gameCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = intensity;
        shakeTimer = duration;
    }
}
