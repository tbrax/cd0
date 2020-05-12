using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay
{
    // Start is called before the first frame update

    public Character c;

    Transform healthText;
    Transform image;
    Transform characterLoc;
    Transform doll;
    string roundS = "F0";
    void Start()
    {
        
    }

    public Transform getDoll()
    {
        
        return doll;
    }

    GameLogic getGame()
    {
        return c.getGameLogic();
    }


    public Vector2 getCharacterPosition()
    {
        return getGame().getCharacterPos(c);
    }

    Transform getChaLoc()
    {
        GameObject[] respawns;
        respawns = GameObject.FindGameObjectsWithTag("CharacterDollList");

        foreach (GameObject respawn in respawns)
        {
            return respawn.transform;
        }

        return null;
    }


    public CharacterDisplay(Character ch)
    {
        c = ch;
        characterLoc = getChaLoc();
        createCharacterDoll();
    }


    public Sprite loadCharacterImage()
    {
        Sprite texture = Resources.Load<Sprite>("Sprites/Characters/square");

        return texture;
    }


    public Transform makeDoll()
    {
        Transform doll = Resources.Load<Transform>("Prefabs/CharacterDis");

        return doll;
    }


    public void updateDollPos()
    {
        Vector2 v = getCharacterPosition();

        //doll.position = doll.position + new Vector3(1, 0, 0);
        doll.position = new Vector2 (v.x,v.y);
        doll.localScale = new Vector2(0.6f, 0.6f);
    }

    public void createCharacterDoll()
    {
        
        Transform doll0 = makeDoll();

        Transform t = GameObject.Instantiate(doll0, getCharacterPosition(), Quaternion.identity);
        healthText = t.GetComponent<CharacterDoll>().healthText;
        image = t.GetComponent<CharacterDoll>().texture;
        image.GetComponent<SpriteRenderer>().sprite = loadCharacterImage();
        t.parent = characterLoc;
        doll = t;

        doll.GetComponent<CharacterDoll>().c = c;

    }


    public void updateInterface()
    {
        updateDollPos();

        string tx = c.getName() + "\n" + getBaseStat("health").ToString(roundS) +
            "/" +
            getBaseStat("maxhealth").ToString(roundS);

        healthText.GetComponent<TMPro.TextMeshProUGUI>().text = tx;

    }

    float getBaseStat(string s)
    {
        return c.getBaseStat(s);
    }




    // Update is called once per frame

}
