using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplayer : MonoBehaviour
{
    public GameController gameController;
    public string text;
    public float range;
    public bool displayed;
    public float distance;

    void Update()
    {
        distance = Vector3.Distance(transform.position, gameController.player.transform.position);
        if (!displayed && distance <= range)
        {
            displayed = true;
            gameController.SetDisplayedText(text);
        }
        else if (displayed && distance > range+0.5f)
        {
            displayed = false;
            gameController.StopDisplayingText();
        }
    }
}
