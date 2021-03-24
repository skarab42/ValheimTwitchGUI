using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardSettingsPanel : MonoBehaviour
{
    public List<GameObject> panels;
    public Dropdown actionsDropdown;

    public void Start()
    {
        actionsDropdown.onValueChanged.AddListener(OnActionChanged);
    }

    private void OnActionChanged(int index)
    {
        for (var i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(i + 1 == index);
        }
    }
}
