using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rzaba : MonoBehaviour
{
    public Player player;
    public Image rzabaImage;

    void Update()
    {
        if(player.moveVector.x<0)
        {
            rzabaImage.gameObject.transform.rotation = Quaternion.Euler(0,180,0)* Quaternion.identity;
        }
        if (player.moveVector.x > 0)
        {
            rzabaImage.gameObject.transform.rotation = Quaternion.identity;
        }
    }
}
