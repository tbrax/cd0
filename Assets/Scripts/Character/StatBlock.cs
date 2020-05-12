using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class StatBlock
{
    public DictionaryOfStringAndString baseStats;
    public DictionaryOfStringAndString damageType;
    public DictionaryOfStringAndString resistType;

    public DictionaryOfStringAndString startDeck;

    public List<string> races;

    DictionaryOfStringAndString baseStatsTemp;
    DictionaryOfStringAndString damageTypeTemp;
    DictionaryOfStringAndString resistTypeTemp;

    Character character;

    string roundS = "F2";

    public string charName;

    public StatBlock(Character c,string name)
    {
        charName = name;
        character = c;
        basicStats();

        startBattle();
    }



    public DictionaryOfStringAndString getStartDeck()
    {
        return startDeck;
    }

    public string getName()
    {
        return charName;
    }



    void basicDeck()
    {
        startDeck.Add("Fire Blast", "5");
        startDeck.Add("Ice Storm", "5");
        startDeck.Add("Lightning Strike", "5");
    }

    void basicStats()
    {
        baseStats = new DictionaryOfStringAndString();
        damageType = new DictionaryOfStringAndString();
        resistType = new DictionaryOfStringAndString();
        baseStatsTemp = new DictionaryOfStringAndString();
        damageTypeTemp = new DictionaryOfStringAndString();
        resistTypeTemp = new DictionaryOfStringAndString();
        startDeck = new DictionaryOfStringAndString();

        baseStats.Add("maxhealth", "100");
        baseStats.Add("initiative", "0");
        baseStats.Add("luck", "0");
        baseStats.Add("handsize", "10");
        baseStats.Add("damage", "100");
        baseStats.Add("resist", "100");
        baseStats.Add("resistTypeStart", "0"); 
        setStat(baseStats,"health",getStat(baseStats,"maxhealth"));
        basicResist();
        basicDeck();
    }

    void basicResist()
    {
        resistType.Add("fire", "100");
        resistType.Add("cold", "150");
        resistType.Add("energy", "50");

    }


    void startBattle()
    {
        baseStats["health"] = baseStats["maxhealth"];
    }
    


    public void addResistType(string type)
    {
        if (!resistType.ContainsKey(type))
        {
            resistType.Add(type, "100");

        }
        if (!resistTypeTemp.ContainsKey(type))
        {
            string newAdd = "0";
            if (baseStats.ContainsKey("resistTypeStart"))
            {
                newAdd = baseStats["resistTypeStart"];
            }
            resistTypeTemp.Add(type, newAdd);
        }

    }

    public void addDamageType(string type)
    {

    }

    float parseNum(Character target,string num)
    {
        return character.parseNum(target,character,num);
    }

    public float calcTakeDamage(float amt, string type)
    {
        addResistType(type);
        float multt = float.Parse(resistType[type]);
        float multt1 = float.Parse(resistTypeTemp[type]);
        float ret = amt * ((multt + multt1) / 100);
        
        return ret;
    }


    DictionaryOfStringAndString getTemp(DictionaryOfStringAndString loc)
    {
        DictionaryOfStringAndString loc2;

        if (loc == baseStats)
        {
            loc2 = baseStatsTemp;
        }
        else if (loc == damageType)
        {
            loc2 = damageTypeTemp;
        }
        else if (loc == resistType)
        {
            loc2 = resistTypeTemp;
        }
        else
        {
            return null;
        }

        return loc2;
    }

    void setStat(DictionaryOfStringAndString loc, string st, float val)
    {
        DictionaryOfStringAndString loc2 = getTemp(loc);

        float ini = 0.0f;

        if (!loc2.ContainsKey(st))
        {
            addTempStat(loc2, st);
        }

        ini = parseNum(character, loc2[st]);
        float nw = ini + val;
        loc[st] = nw.ToString(roundS);
    }


    void addTempStat(DictionaryOfStringAndString loc, string st)
    {
        loc.Add(st, "0");
    }


    public float getBaseStat(string st)
    {
        return getStat(baseStats, st);
    }

    public float getResistStat(string st)
    {
        return getStat(resistType, st);
    }

    public float getDamageStat(string st)
    {
        return getStat(damageType, st);
    }



    float getStat(DictionaryOfStringAndString loc, string st)
    {
        DictionaryOfStringAndString loc2 = getTemp(loc);
        float ini = 0.0f;
        if (loc.ContainsKey(st))
        {
            ini += parseNum(character, loc[st]);
        }
        if (!loc2.ContainsKey(st))
        {
            addTempStat(loc2, st);
        }
        ini += parseNum(character, loc2[st]);
        return ini;
    }


    public void takeDamage(float damage)
    {
        float hpVal = getStat(baseStats, "health");
        float newVal = hpVal - damage;
        setStat(baseStats,"health",newVal);
    }


}
