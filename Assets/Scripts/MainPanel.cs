using UnityEngine;
using UnityEngine.EventSystems;

public class MainPanel : MonoBehaviour
{
    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
