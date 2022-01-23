using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SC_HUD_BlackPanel : MonoBehaviour
{
    public Image img;
    public TextMeshProUGUI tmp;

    public void Start()
    {
        img = gameObject.GetComponent<Image>();
        tmp = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(FadeImage(true));
    }

    public void ShowMessage(string pMessage)
    {
       tmp.text = pMessage;
        StartCoroutine(FadeImage(false));
    }

    public void HideMessage()
    {
        StartCoroutine(FadeImage(true));
    }


    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            for (float i = 2f; i >= 0; i -= Time.deltaTime)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, Mathf.Clamp(img.color.a - .3f, 0, .69f));
                tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, Mathf.Clamp(tmp.color.a - .5f, 0, 1));
                if (i < 0)
                {
                    tmp.text = "";
                }
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= 2f; i += Time.deltaTime)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, Mathf.Clamp(img.color.a + .3f, 0, .69f));
                tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, Mathf.Clamp(tmp.color.a + .5f, 0, 1));
                yield return null;
            }
        }
    }
}
