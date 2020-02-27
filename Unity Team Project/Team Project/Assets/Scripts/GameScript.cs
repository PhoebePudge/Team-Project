using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameScript : MonoBehaviour
{
    
    #region variables
    //array of players for reference
    [SerializeField] public GameObject[] players;

    //array of gameobjects
    //could create throughout code later
    [SerializeField] GameObject[] playergm;

    //Struct is used to instanceat wepons from a predetermined value
    [SerializeField] weponDatabse[] wd;

    [SerializeField] Sprite iBI;

    [System.Serializable]
    public struct weponDatabse
    {
        [SerializeField] public Sprite Sprite;
        [SerializeField] public string Name;
        [Range(1, 2)] [SerializeField] public int typeIndex; // 1: melee; 2: ranged
        [SerializeField] public int damage;

    }

    #endregion

    [SerializeField] weapon wp;

    void Start()
    {
        Debug.Log("starting");
        players = new GameObject[4];
        ReadDataFile();
        //create 4 players
        //give then their gameobject and some basic paramiters

    }

    void CallWeaponCreation(int playerIndex, int weponDatabaseIndex)
    {
        wp = new weapon
        {
            Sprite = wd[weponDatabaseIndex].Sprite,
            Name = wd[weponDatabaseIndex].Name,
            typeIndex = wd[weponDatabaseIndex].typeIndex,
            damage = wd[weponDatabaseIndex].damage,
            //pl = players[playerIndex]
        };
        players[playerIndex].GetComponent<PlayerInventory>().AddWeapon(wp);

    }
    void Update()
    {
    }

    string line = "";

    string[] words = new string[5];

    void ReadDataFile()
    {
        StreamReader reader = new StreamReader(@"Assets\PlayerInformation.txt");

        line = reader.ReadLine();
        int counter2 = 0;
        if (line == null)
        {
            Debug.Log("The File is empty????");
        }
        while (line != null && counter2 < 4)
        {
            
            
            int counter = 0;
            foreach (char i in line)
            {
                if (i == ',')
                {
                    Debug.Log(counter2 + " : "+ words[counter]);
                    counter++;
                    
                }
                else
                {
                    words[counter] = words[counter] + i;
                }
            }
            line = reader.ReadLine();
            Debug.Log("counter2 is: "+ counter2);

            CreatePlayer(counter2);
            counter2++;

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = "";
            }
        }
    }

    void CreatePlayer(int arrayIndex)
    {
        Debug.Log(words[4]);
        players[arrayIndex] = new GameObject();
        players[arrayIndex].name = "Player " + (arrayIndex + 1);

        players[arrayIndex].AddComponent<PlayerInventory>();
        players[arrayIndex].GetComponent<PlayerInventory>().affix = (arrayIndex + 1);

        players[arrayIndex].AddComponent<PlayerMovement>();
        players[arrayIndex].GetComponent<PlayerMovement>().affix = (arrayIndex + 1);

        players[arrayIndex].AddComponent<PlayerUI>();
        players[arrayIndex].GetComponent<PlayerUI>().affix = (arrayIndex + 1);

        string className = (string)words[0];
        GameObject obj = playergm[arrayIndex];
            
        Sprite defaultIndevortyIndex = iBI;

        //if (words[4] == "False")
        //{
        //    players[arrayIndex].isActive = false;
        //}
        //else
        //{
        //    players[arrayIndex].isActive = true;
        //}

        CallWeaponCreation(arrayIndex, 0);
        CallWeaponCreation(arrayIndex, 2);
    }
}
