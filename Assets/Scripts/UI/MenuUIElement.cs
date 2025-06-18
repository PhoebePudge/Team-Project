using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUIElement
{
    public GameObject UIElement;
    public Image Border;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Description;
    public MenuUIElement()
    {
        UIElement = new GameObject();
        UIElement.name = "MenuUIElement";
        UIElement.AddComponent<GridLayoutGroup>();
        

        Border = new GameObject().AddComponent<Image>();
        Border.name = "Border";
        Border.sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0.0f, 0.0f, 4, 4), new Vector2(0.5f, 0.5f), 100.0f);
        Border.color = Color.grey;

        Title = new GameObject().AddComponent<TextMeshProUGUI>();
        Title.name = "Title";

        Description = new GameObject().AddComponent<TextMeshProUGUI>();
        Description.name = "Description";
    }
    public void setParent(GameObject parent)
    {
        UIElement.transform.parent = parent.transform;
        UIElement.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / FindNumberOfPlayers(), Screen.height);
        UIElement.GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.width / FindNumberOfPlayers(), Screen.height);

        Border.transform.parent = UIElement.transform;

        Title.transform.parent = UIElement.transform;
        Description.transform.parent = UIElement.transform;
    }
    private int FindNumberOfPlayers()
    {
        return 3;
    }
}
