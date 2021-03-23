using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons = new List<TabButton>();

    public void Add(TabButton button)
    {
        tabButtons.Add(button);
    }

    public void OnTabSelect(TabButton tabButton)
    {
        foreach (TabButton tab in tabButtons)
        {
            tab.Unselect();
        }

        tabButton.Select();
    }
}
