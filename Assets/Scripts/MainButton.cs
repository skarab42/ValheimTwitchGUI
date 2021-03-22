using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainButton : MonoBehaviour
{
    public Button button;
    public Text text;

    public void OnClick(UnityAction action)
    {
        button.onClick.AddListener(action);
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }
}
