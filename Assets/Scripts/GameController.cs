using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public Player player;
    [SerializeField] TMP_Text textDisplay;
    public float alpha;
    [SerializeField] int alphaFrames;

    public void SetDisplayedText(string text)
    {
        textDisplay.text = text;
        StartCoroutine(IncreaseAlpha());
    }

    private IEnumerator IncreaseAlpha()
    {
        for(int i=0; i<alphaFrames; i++)
        {
            alpha += 1f/alphaFrames;
            textDisplay.color = SetAlpha(textDisplay.color, alpha);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void StopDisplayingText()
    {
        StartCoroutine(DecreaseAlpha());
    }

    private IEnumerator DecreaseAlpha()
    {
        for (int i = 0; i < alphaFrames; i++)
        {
            alpha -= 1f/alphaFrames;
            textDisplay.color = SetAlpha(textDisplay.color, alpha);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private Color SetAlpha(Color color, float alpha)
    {
        color = new Color(color.r, color.g, color.b, alpha);
        return color;
    }
}
