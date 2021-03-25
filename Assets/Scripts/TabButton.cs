using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool selected;
    public TabGroup tabGroup;
    public GameObject panel;

    public Color32 normalColor = new Color(255, 255, 255, 255);
    public Color32 selectedColor = new Color(255, 255, 255, 255);
    public Color32 highlightedColor = new Color(255, 255, 255, 255);

    private Image image;

    public void Awake()
    {
        image = GetComponent<Image>();
        image.color = normalColor;

        tabGroup.Add(this);

        if (selected)
            tabGroup.OnTabSelect(this);
    }

    public bool IsSelect()
    {
        return selected;
    }

    public void Select()
    {
        selected = true;
        image.color = selectedColor;

        panel.SetActive(true);
    }

    public void Unselect()
    {
        selected = false;
        image.color = normalColor;

        panel.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelect(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (selected)
            return;

        image.color = highlightedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (selected)
            return;

        image.color = normalColor;
    }
}
