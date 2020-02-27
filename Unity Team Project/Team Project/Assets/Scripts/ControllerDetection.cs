using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


using System.IO;

//called at the menu
public class ControllerDetection : MonoBehaviour
{
    [SerializeField] GameObject[] ControllerIcons = new GameObject[4];

    [SerializeField] Sprite ControllerTemplate;

    [SerializeField] Slider slider;

    [SerializeField] int[] playerClassIndex = new int[4];

    [SerializeField] playerClass[] importerArray = new playerClass[4];

    [SerializeField] playerClass[] classTemplates;

    [SerializeField] GameObject[] Text;

    [SerializeField] GameObject TextParent;
    StreamWriter sr;

    [System.Serializable]
    struct playerClass
    {
        public string ClassName;
        public int MaxHealth;
        public int Speed;
        public int Damage;
        public bool isActive;
    }


    [SerializeField] bool[] justClicked;


    // Start is called before the first frame update
    void Start()
    {
        justClicked = new bool[4];
        Text = new GameObject[4];
        

        for (int i = 0; i < ControllerIcons.Length ; i++)
        {
            ControllerIcons[i] = new GameObject();
            ControllerIcons[i].AddComponent<SpriteRenderer>();

            ControllerIcons[i].GetComponent<SpriteRenderer>().sprite = ControllerTemplate;
            ControllerIcons[i].GetComponent<SpriteRenderer>().color = Color.red;
            ControllerIcons[i].transform.position = new Vector3(i * 4 - 6, 0, 0);

            importerArray[i].isActive = false;

            ControllerIcons[i].name = "Controller Icon";

            playerClassIndex[i] = 1;

            ChangePlayerClass(0, i);
            justClicked[i] = new bool();
            justClicked[i] = false;

            Text[i] = new GameObject();
            Text[i].transform.position = new Vector3(i * 4 - 6, 0, 0);
            Text[i].AddComponent<TextMeshPro>();
            Text[i].GetComponent<TextMeshPro>().fontSize = 3;
            Text[i].GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.MidlineGeoAligned;
            Text[i].name = "Text Icon";

        }
        //playerCursorImage = Cursor;

        
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ControllerIcons.Length; i++)
        {
            
            if (Input.GetButtonDown("P" + (i + 1) + "Return"))
            {
                
                toggleControllerIcon(i);

            }

            if (Input.GetAxis("P" + (i + 1) + "TriggerLeft") != 0)
            {
                if (!justClicked[i])
                {
                    ChangePlayerClass(playerClassIndex[i] - 1, i);
                }

                justClicked[i] = true;
            }
            else if (Input.GetAxis("P" + (i + 1) + "TriggerRight") != 0)
            {
                if (!justClicked[i])
                {
                    ChangePlayerClass(playerClassIndex[i] + 1, i);
                }

                justClicked[i] = true;
            }
            if (Input.GetAxis("P" + (i + 1) + "TriggerRight") == 0 && Input.GetAxis("P" + (i + 1) + "TriggerLeft") == 0)
            {
                justClicked[i] = false;
            }

            if (ControllerIcons[i].GetComponent<SpriteRenderer>().color == Color.red)
            {
                Text[i].GetComponent<TextMeshPro>().text = "Press B to join";
            }
            else
            {
                Text[i].GetComponent<TextMeshPro>().text = classTemplates[playerClassIndex[i]].ClassName;
            }
            
        }

        playerTimer();
    }

    void ChangePlayerClass(int classIndex, int playerIndex)
    {
        if (classIndex >= classTemplates.Length || classIndex < 0)
        {
            Debug.Log("Player " + (playerIndex + 1) + " tried to access out of bound class at index " + classIndex);
        }
        else
        {
            Debug.Log("Player " + (playerIndex + 1) + " has changed class to " + classTemplates[classIndex].ClassName + " (" + classIndex + ")");
            importerArray[playerIndex] = classTemplates[classIndex];
            playerClassIndex[playerIndex] = classIndex;
            
        }

        
    }

    void ExportPlayerClass()
    {
        var fileName = @"Assets\PlayerInformation.txt";

        if (File.Exists(fileName))
        {
            Debug.Log(fileName + " already exists and is being cleared");
            File.WriteAllText(@fileName, string.Empty);
            sr = new StreamWriter(fileName);
        }
        else
        {
            Debug.Log(fileName + " does not exist and therefore is being created");
            sr = File.CreateText(fileName);
        }

        

        for (int i = 0; i < ControllerIcons.Length; i++)
        {
            if (importerArray[i].ClassName == null)
            {
                sr.WriteLine(";");
            }
            else
            {
                sr.WriteLine(importerArray[i].ClassName + "," + importerArray[i].MaxHealth + "," + importerArray[i].Damage + "," + importerArray[i].Speed + "," + importerArray[i].isActive);

            }
        }
        sr.Close();
    }

    void toggleControllerIcon(int index)
    {
        if (ControllerIcons[index].GetComponent<SpriteRenderer>().color == Color.green)
        {
            ControllerIcons[index].GetComponent<SpriteRenderer>().color = Color.red;
            importerArray[index].isActive = false;
        }
        else
        {
            ControllerIcons[index].GetComponent<SpriteRenderer>().color = Color.green;
            importerArray[index].isActive = true;
        }
    }

    #region transitionToGame
    int counter = 0;
    bool isHoldingDown;

    void playerTimer()
    {
        
        isHoldingDown = false;

        for (int i = 0; i < ControllerIcons.Length; i++)
        {
            if (Input.GetButton("P" + (i + 1) + "Enter"))
            {
                isHoldingDown = true;

            }
        }


        if (isHoldingDown)
        {
            counter++;
        } else
        {
            counter = 0;
        }

        slider.value = counter;

        if (counter == 100)
        {
            ExportPlayerClass();
            Debug.Log("Play Game");
            
            SceneManager.LoadScene(1);
        }
    }
    #endregion
}
