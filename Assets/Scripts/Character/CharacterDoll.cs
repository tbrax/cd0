using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDoll : MonoBehaviour
{
    public Transform healthText;
    public Transform texture;
    public Character c;


    void OnMouseDown()
    {
        c.charClick();
    }
}
