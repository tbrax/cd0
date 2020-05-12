using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{

    List<Transform> dolls;


    void makeCard()
    {

    }

    public Transform makeCardDoll()
    {
        Transform doll = Resources.Load<Transform>("Prefabs/CardDoll");

        return doll;
    }



    void clearDolls()
    {
        foreach (Transform d in dolls)
        {
            Destroy(d);
        }
    }

    Vector2 getCardPosition(int idx)
    {
        int rowSize = 0;



        return new Vector2(0, 0);
    }

    public void displayList(List<Card> cardList)
    {
        clearDolls();


        int cardCount = 0;
        foreach (Card c in cardList)
        {
            Transform t = makeCardDoll();

            Transform d = GameObject.Instantiate(t, getCardPosition(cardCount), Quaternion.identity);

            dolls.Add(d);
            cardCount += 1;
        }


    }
}
