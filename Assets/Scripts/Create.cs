using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject[] players;

    //set of possible positions for players to spawn at
    
    
    [Header("Testing Variables")]
    [SerializeField] bool overrideTextures = false;
    [SerializeField] bool overideStartMenuUI = false;
    
    void Start()
    {
        gameObject.AddComponent<StartMenuUI>().enabled = false;
        #region Calculate Number Of Controllers Connected
        int controllerNumbers = 3;
        #endregion

        //Set number of players to amount of controllers connected
        players = new GameObject[controllerNumbers];

        #region Player Creation
        //loop through every player for creation
        for (int index = 0; index < controllerNumbers; index++)
        {
            //create object
            players[index] = new GameObject();

            //rename object
            players[index].name = "Player " + index;

            players[index].tag = "Player";
            //add monobehaviour
            players[index].AddComponent<PlayerMisc>();
            players[index].AddComponent<PlayerUI>();
            players[index].AddComponent<PlayerMovement>();

            //index local scale to make more visiable
            players[index].transform.localScale = new Vector3(10,10,10);
            //Testing Overide Sprite
            if (overrideTextures)
            {
                //create square texture
                players[index].AddComponent<SpriteRenderer>().sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0.0f, 0.0f, 4, 4), new Vector2(0.5f, 0.5f), 100.0f);
                //change colours
                float colourIndex = index / controllerNumbers;
                players[index].GetComponent<SpriteRenderer>().color = new Color(colourIndex, colourIndex, colourIndex, 1);
            }

            //TODO----------------------------------------------------------------------------------------------------------------------
            //Set Default Sprite Texture
            if (!overrideTextures)
            {

            }
        }
        #endregion


    }
    void Update()
    {
        if (overideStartMenuUI)
        {
            gameObject.GetComponent<StartMenuUI>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<StartMenuUI>().enabled = false;
        }
    }
}
