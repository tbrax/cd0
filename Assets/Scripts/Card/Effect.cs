﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

[Serializable]
public class Effect
{
    // Start is called before the first frame update

    Card card;

    public Action act;
    List<Criteria> criteria;
    public string targets;

    public Effect deepCopy()
    {
        Effect e = new Effect(card);
        Action a = act.deepCopy();
        e.addAction(a);
        e.targets = targets;
        foreach (Criteria ct in criteria)
        {
            Criteria cn = ct.deepCopy();
            e.addCriteria(cn);
        }
            return e;
    }

    public string getDesc()
    {
        string temp = "";
        if (criteria.Count > 0)
        {
            temp += "If ";
            for(var i=0; i< criteria.Count;i++)
            {
                temp += criteria[i].getDesc();
                if (i< criteria.Count-1)
                {
                    temp += "\n";
                }

            }
        }
        temp += act.getDesc();

        return temp;
    }

    public void addCriteria(Criteria c)
    {
        criteria.Add(c);
    }
    public void addAction(Action a)
    {
        act = a;
    }

    public Effect(Card c)
    {
        card = c;
        setupEffect(c);
    }

    public void setupEffect(Card c)
    {
        card = c;
        if (act == null)
        {
            act = new Action(this);
        }
        if (criteria == null)
        {
            criteria = new List<Criteria>();
        }
        if (targets == null)
        {
            targets = "select";
        }


        act.setupAction();
            
    }




    public float parseNum(Character tar, Character own,string num)
    {
        return card.parseNum(tar,own,num);
    }

    bool isValid(Character tar)
    {
        bool bas = true;
        foreach (Criteria ct in criteria)
        {
            if (!ct.isValid(tar,getCharacter()))
            {
                bas = false;
            }
        }
        return bas;
    }

    List<Character> targetLiteral(Character tar)
    {
        List<Character> tempTargets = new List<Character>();
        tempTargets.Add(tar);
        List<Character> targets = new List<Character>();
        foreach (Character ct in tempTargets)
        {
            if (isValid(ct))
            {
                targets.Add(ct);
            }
        }
        return targets;
    }

    List<Character> allEnemy(Character tar)
    {
        List<Character> targets = new List<Character>();
        return targets;
    }

    public Character getCharacter()
    {
        return card.getCharacter();
    }

    List<Character> getTargets(Character source,Character target)
    {
        List<Character> ls = new List<Character>();
        
        switch (targets)
        {
            case "select":
                ls.Add(target);
                
                break;
            case "self":
                ls.Add(source);
                break;
            case "allteam":
                foreach (Character ct in target.getTeam().getChas())
                {
                    ls.Add(ct);
                }
                break;
            case "randomteam":
                List<Character> cts = target.getTeam().getChas();
                ls.Add(cts[UnityEngine.Random.Range(0, cts.Count)]);

                break;
            case "allteamoher":
                foreach (Character ct in target.getTeam().getChas())
                {
                    if (ct != target)
                    {
                        ls.Add(ct);
                    }
                }
                break;
            case "allally":
                foreach (Character ct in source.getTeam().getChas())
                {
                    ls.Add(ct);
                }
                break;
            case "allallyother":
                foreach (Character ct in source.getTeam().getChas())
                {
                    if (ct != source)
                    {
                        ls.Add(ct);
                    }   
                }
                break;

            default:
                ls.Add(target);
                break;
        }

        return ls;
    }

    public void use(Character source,Character target)
    {
        List<Character> listTargets = getTargets(source,target);

        foreach (Character ct in listTargets)
        {
            if (isValid(ct))
            {
                
                act.use(source, ct);
            }
        }

    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
