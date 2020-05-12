using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    Character character;
    List<Card> cards = new List<Card>();



    List<Card> hand = new List<Card>();
    List<Card> grave = new List<Card>();
    List<Card> dec = new List<Card>();
    List<Card> discard = new List<Card>();

    bool validDeck = true;
    // Start is called before the first frame update

    /*public object this[int i]
    {
        get { return cards[i]; }
        set { cards[i] = (Card)value; }
    }*/

    public object this[int i] => this.cards[i];


    public Deck(Character c)
    {
        character = c;
        

    }

    public void setupDeck()
    {
        foreach (Card car in cards)
        {
            Card cn = car.deepCopy();
            dec.Add(cn);
        }
    }

    public void loadCards()
    {

    }

    public List<Card> getHand()
    {

        return cards;
        //return hand;
    }

    public List<Card> getGrave()
    {
        return grave;
    }

    int getMaxHandSize()
    {
        return (int)character.getBaseStat("handsize");
    }

    public List<Card> getDeck(int num = -1,int ordered = -1)
    {
        return dec;
    }

    void discardToDraw()
    {
        foreach (Card car in discard)
        {
            dec.Add(car);
        }
        discard.Clear();

        shuffle();
    }

    void deckOut()
    {
        validDeck = false;
    }

    void checkEmpty()
    {
        if (dec.Count <= 0)
        {
            discardToDraw();
        }

        if (dec.Count <= 0)
        {
            deckOut();
        }

    }

    void drawOne()
    {
        checkEmpty();

        if (validDeck)
        {
            Card c = dec[0];
        }
        
    }

    public int getCurrentHandSize()
    {
        return hand.Count;
    }

    public void shuffle()
    {
        for (int i = 0; i < dec.Count; i++)
        {
            Card temp = dec[i];
            int randomIndex = Random.Range(i, dec.Count);
            dec[i] = dec[randomIndex];
            dec[randomIndex] = temp;
        }

    }
    public void draw(int amt)
    {
        int min = Mathf.Min(amt, getMaxHandSize() - getCurrentHandSize());
        for (var i=0;i<min;i++)
        {
            drawOne();
        }
    }


    public int length()
    {
        return cards.Count;
    }



    public void addCard(Card c)
    {
        c.setDeck(this);
        cards.Add(c);


    }

    public float parseNum(Character tar,Character own, string num)
    {
        return character.parseNum(tar,own,num);
    }

    public Character getCharacter()
    {
        return character;
    }

    public void setCharacter(Character c)
    {
        character = c;
    }

    public Deck(Deck prev)
    {

    }

    public Deck deepCopy()
    {
        Deck td = new Deck(character);

        foreach (Card car in cards)
        {
            Card carCopy = car.deepCopy();
            td.addCard(carCopy);
        }

        return td;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
