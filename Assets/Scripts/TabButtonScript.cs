using UnityEngine;
using UnityEngine.EventSystems;

public class TabButtonScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject panel;
    public GameObject panels;

    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < panels.transform.childCount; i++)
        {
            var go = panels.transform.GetChild(i).gameObject;

            go.SetActive(go.name == panel.name);
        }
    }
}
