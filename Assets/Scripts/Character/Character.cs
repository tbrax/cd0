using Packages.Rider.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Character
{


    public StatBlock stats;
    public Deck deckBattle;
    Team team;
    GameLogic game;
    public CharacterDisplay display;


    private void Start()
    {
        
    }

    public Character()
    {

    }

    public CharacterDisplay getDisplay()
    {
        return display;
    }

    public void charClick()
    {
        game.characterSelect(this);
    }

    public GameLogic getGameLogic()
    {
        return game;
    }

    public void setGame(GameLogic g,string name)
    {
        game = g;
        make(name);
        
    }

    public void addTeam(Team t)
    {
        team = t;
    }

    public void makeDisplay()
    {
        display = new CharacterDisplay(this);
    }

    public Team getTeam()
    {
        return team;
    }



    public List<Card> getHand()
    {
        return deckBattle.getHand();
    }

    public string getName()
    {
        return stats.getName();
    }

    public StatBlock getStats()
    {
        return stats;
    }




    public void make(string name)
    {
        stats = new StatBlock(this,name);
        setupDeck();
        makeDisplay();

    }


    public void useCard(Card c, Character target)
    {
        c.use(this,target);
    }

    public void updateInterface()
    {
        display.updateInterface();

    }

    public void addCard(Card c)
    {
        deckBattle.addCard(c);
    }

    void setupDeck()
    {
        DictionaryOfStringAndString deckdict = stats.getStartDeck();

        deckBattle = game.createDeck(deckdict,this);
    }

    public void setupStats(StatBlock stat)
    {
        stats = stat;
    }


    public float parseNum(Character target, Character own, string num)
    {
        return game.parseNum(target,own,num);
    }




    public string parseType(Character target, Character own, string type)
    {
        return type;
    }

    public void takeDamage(Character source, string type, string amt)
    {
        float trueAmt = parseNum(this,source,amt);
        string trueType = parseType(this, source, type);
        float damAmt = stats.calcTakeDamage(trueAmt,trueType);

        
        stats.takeDamage(damAmt);
        updateInterface();
    }

    public float luckRoll()
    {
        float l = UnityEngine.Random.Range(0.0f, 1.0f);
        l = l * (1 + (getBaseStat("luck")/100));
        if (l > 1.0f)
        {
            l = 1.0f;
        }
        return l;
    }

    public void dealDamage(Character target, string type, string amt)
    {
        
        target.takeDamage(this, type, amt);


    }

    public float getBaseStat(string st)
    {
        return stats.getBaseStat(st);
    }

    public float getResistStat(string st)
    {
        return stats.getResistStat(st);
    }

    public float getDamageStat(string st)
    {
        return stats.getDamageStat(st);
    }



    public bool isAlive()
    {
        return true;
    }

    public bool canFight()
    {
        return true;
    }

    void doChange(Character target, string change)
    {

    }

    void handleChange(Change change)
    {

    }

}
