using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public void saveCardDat(Card data,string saveName0)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string saveName = "card0.dat";
        FileStream file = File.Open(Application.persistentDataPath + saveName, FileMode.Open);
        bf.Serialize(file, data);
        file.Close();
    }

    public void saveCharacterJSON(Character data, string saveName)
    {
        string path = Application.persistentDataPath + "/character";
        var folder = Directory.CreateDirectory(path);

        string card = JsonUtility.ToJson(data.getStats());
        File.WriteAllText(path + "/" + saveName + ".json", card);
        //Card save = JsonUtility.FromJson<Card>(json);
        Debug.Log("Saved character: " + saveName);
    }

    public Character loadCharacterJSON(string saveName)
    {
        string path = Application.persistentDataPath + "/character/" + saveName + ".json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            //File.WriteAllText(Application.persistentDataPath + "/" + saveName + ".json", potion);
            StatBlock stats = JsonUtility.FromJson<StatBlock>(json);

            Character c = new Character();
            c.setupStats(stats);
            return c;
        }
        
        return null;
    }



    public void saveCardJSON(Card data, string saveName)
    {
        string path = Application.persistentDataPath + "/cards";
        var folder = Directory.CreateDirectory(path);

        string card = JsonUtility.ToJson(data);
        File.WriteAllText(path + "/" + saveName + ".json", card);
        //Card save = JsonUtility.FromJson<Card>(json);
        Debug.Log("Saved card: " + saveName);
    }

    public Card loadCardJSON(string saveName)
    {
        string path = Application.persistentDataPath + "/cards/" + saveName + ".json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            //File.WriteAllText(Application.persistentDataPath + "/" + saveName + ".json", potion);
            Card card = JsonUtility.FromJson<Card>(json);
            card.setupCard(saveName, null);
            return card;
        }
        return null;
    }


    public Card loadCardDat(string saveName)
    {
        //string saveName = "card0.dat";

        if (File.Exists(Application.persistentDataPath + saveName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + saveName, FileMode.Open);
            Card card = (Card)bf.Deserialize(file);
            file.Close();
            return card;
        }
        return null;
    }

}
