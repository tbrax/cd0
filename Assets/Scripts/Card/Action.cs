using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class Action
{
    public DictionaryOfStringAndString actionStats;

    //string json = JsonUtility.ToJson(this);

    public Action(Effect e)
    {
        defaultAcction();
    }

    public void setupAction()
    {
        defaultAcction();
    }

    public string getDesc()
    {
        string temp = "";

        foreach (KeyValuePair<string, string> attach in actionStats)
        {
            temp += attach.Key + "-" + attach.Value + " ";
        }

        return temp;
    }
    public void defaultAcction()
    {

        if (!actionStats.ContainsKey("actionType"))
        {
            addActionStat("actionType", "dealdamage");
            addActionStat("elementType", "fire");
            addActionStat("value", "12.0");
            addActionStat("targets", "select");
        }


    }
    public Action()
    {

    }


    public void addActionStat(string type, string val)
    {
        actionStats.Add(type,val);
    }

    public Action deepCopy()
    {
        Action a = new Action();

        foreach (KeyValuePair<string, string> attach in actionStats)
        {
            a.addActionStat(attach.Key, attach.Value);
        }

        return a;
    }





    public void use(Character source, Character target)
    {
        switch (actionStats["actionType"])
        {
            case "dealdamage":
                
                source.dealDamage(target, actionStats["elementType"], actionStats["value"]);
                break;
            case "heal":
                break;
            default:
                return;
        }


    }


}
