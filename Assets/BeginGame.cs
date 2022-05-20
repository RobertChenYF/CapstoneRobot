using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BeginGame : MonoBehaviour
{
    public SoundTrackManager trackManager;
    public Light carLight;
    public Light carHeadLight;
    public Material headLightMat;
    public Material arrowMat;
    public TextMeshProUGUI title;
    public TextMeshProUGUI pressToStart;
    public TextMeshProUGUI movementPrompt;
    public TextMeshProUGUI endCredit;
    public GameObject VC;
    public SimpleCarController carController;
    public bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        arrowMat.SetColor("_ArrowColor",Color.gray);
        headLightMat.SetColor("_EmissionColor", Color.white*0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Grap") && start == false)
        {
            Debug.Log("START");
            start = true;
            BeginGameFunction();
        }
    }

    public void BeginGameFunction()
    {
        
        trackManager.startPlay(0);
        StartCoroutine(FadeOut());
    }

    public void FadeInTextFunction(TextMeshProUGUI text)
    {
        StartCoroutine(FadeInText(text, 1.0f));
    }

    public void FadeOutTextFunction(TextMeshProUGUI text)
    {
        StartCoroutine(FadeOutText(text));
    }

    public void FadeInImageFunction(RawImage image)
    {

        StartCoroutine(FadeInImage(image, 0.5f));
    }

    public void JustBegin()
    {
        carHeadLight.intensity = 1.0f;
        title.color = new Color(1, 1, 1, 0);
        pressToStart.color = new Color(1, 1, 1, 0);
        carController.enabled = true;
        headLightMat.SetColor("_EmissionColor", Color.white * 2);
        carLight.intensity = 1.0f;
        start = true;
    }

    IEnumerator FadeInImage(RawImage image, float speed)
    {
        for (float a = 0; a <= 1; a += speed * Time.deltaTime)
        {

            image.color = new Color(image.color.r, image.color.g, image.color.b, a);
            yield return null;

        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        FadeInTextFunction(endCredit);
    }

    IEnumerator FadeInText(TextMeshProUGUI text, float speed)
    {
        for (float a = 0; a <= 1; a += speed * Time.deltaTime)
        {

            text.color = new Color(text.color.r,text.color.g,text.color.b, a);
            yield return null;

        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    }

    IEnumerator FadeOutText(TextMeshProUGUI text)
    {
        for (float a = 1; a >= 0; a -= 1.0f * Time.deltaTime)
        {

            text.color = new Color(text.color.r, text.color.g, text.color.b, a);
            yield return null;

        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }

    IEnumerator FadeOut()
    {

        for (float a = 1f; a >= 0; a -= 0.5f * Time.deltaTime)
        {

            carHeadLight.intensity = 1.0f - a;
            carLight.intensity = 1.0f - a;
            headLightMat.SetColor("_EmissionColor", Color.white * (1.0f - a) * 2);
            title.color = new Color(1, 1, 1, a);
            pressToStart.color = new Color(1, 1, 1, a);
            yield return null;

        }

        carHeadLight.intensity = 1.0f;
        title.color = new Color(1, 1, 1, 0);
        pressToStart.color = new Color(1, 1, 1, 0);
        VC.SetActive(true);
        carController.enabled = true;
        headLightMat.SetColor("_EmissionColor", Color.white * 2);
        carLight.intensity = 1.0f;
        FadeInTextFunction(movementPrompt);

    }
}
