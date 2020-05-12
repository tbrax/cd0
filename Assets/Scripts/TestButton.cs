using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    public GameLogic game;
    //public List<Character> characters;
    public int buttonNum;

    private void Start()
    {
        setupNum();
    }

    void setupNum()
    {
        switch (buttonNum)
        {
            case 0:
                break;
            case 1:
                break;
            default:
                break;
        }
    }


    Character getCharacter(int index)
    {
        return game.getCharacter(index);
    }
    void setup0()
    {
        
    }


    void test0()
    {
        game.saveTempCard();
    }

    void test1()
    {
        game.saveTempCharacter();
    }

    void test2()
    {
        game.endTurn();
    }

    void test3()
    {
        string name = "bob";
        Character c0 = getCharacter(0);
        game.saveCharacter(c0, name);
    }


    void test()
    {
        switch (buttonNum)
        {
            case 0:
                test0();
                break;
            case 1:
                test1();
                break;
            case 2:
                test2();
                break;
            case 3:
                test3();
                break;
            default:
                break;
        }
    }

    void OnMouseDown()
    {
        test();
    }
}
