using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartMenuUI : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField] private Canvas canvas;
    [SerializeField] private HorizontalLayoutGroup layout;
    [SerializeField] private MenuUIElement[] element;
    private void OnEnable()
    {
        if (layout != null)
        {
            layout.gameObject.SetActive(true);
        }
    }
    private void OnDisable()
    {
        if (layout != null)
        {
            layout.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        //find canvas
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        //make a element for each player
        element = new MenuUIElement[numberOfPlayers()];

        layout = new GameObject().AddComponent<HorizontalLayoutGroup>();
        layout.transform.parent = canvas.transform;
        layout.name = "Start Menu";

        layout.GetComponent<RectTransform>().position = new Vector2(50, -50);
        layout.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        layout.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);


        //layout.spacing = Screen.width / element.Length;
        layout.spacing = 2f;
        layout.childForceExpandWidth = false;
        layout.childForceExpandHeight = false;
        layout.childScaleHeight = false;
        layout.childScaleWidth = false;
        layout.childControlHeight = false;
        layout.childControlWidth = false;

        layout.transform.position = new Vector3(0, Screen.height, 0);
        //loop though each element
        for (int index = 0; index < element.Length; index++)
        {
            //instanciate
            element[index] = new MenuUIElement();

            //parent to canvas
            element[index].setParent(layout.gameObject);
        }
    }
    private int numberOfPlayers()
    {
        ////return GameObject.Find("Main Camera").gameObject.GetComponents<Create>().players.length;
        return 3;
    }
}
