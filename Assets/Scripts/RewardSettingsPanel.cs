using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardSettingsPanel : MonoBehaviour
{
    public List<MessageSettings> panels;
    public Dropdown actionsDropdown;
    public RewardSettings settings;

    public void Awake()
    {
        actionsDropdown.onValueChanged.AddListener(OnActionChanged);
    }

    private void OnActionChanged(int index)
    {
        for (var i = 0; i < panels.Count; i++)
        {
            var active = i + 1 == index;

            panels[i].gameObject.SetActive(active);

            if (active)
            {
                settings.currentSettingsPanel = panels[i];
                panels[i].SetData(settings.reward.data);
            }
        }
    }
}
