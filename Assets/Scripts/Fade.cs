using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fade : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public GameObject textContainer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fade());
    }


    private IEnumerator fade()
    {
        
        float duration = 2f; //fade out over 2 seconds
        float currentTime = 0f;
        textDisplay.color = new Color(textDisplay.color.r, textDisplay.color.g, textDisplay.color.b, 255);
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            textDisplay.color = new Color(textDisplay.color.r, textDisplay.color.g, textDisplay.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        textContainer.SetActive(false);

        yield break;

    }
}
