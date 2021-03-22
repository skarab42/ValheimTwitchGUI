﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RefreshRewardButton : MonoBehaviour
{
    public Button button;

    public void OnClick(UnityAction action)
    {
        button.onClick.AddListener(action);
    }
}
