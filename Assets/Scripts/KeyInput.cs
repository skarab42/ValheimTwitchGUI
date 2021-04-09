using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyCodeArgs : EventArgs
{
    public KeyCode Code { get; set; }
}

public delegate void KeyCodeHandler(object sender, KeyCodeArgs e);

public class KeyInput : MonoBehaviour
{
    public event KeyCodeHandler OnCode;

    public Text label;
    public Button button;
    public Text buttonText;

    public bool waitForKey = true;

    public List<KeyCode> mouseCodes = new List<KeyCode> {
        KeyCode.Mouse0,
        KeyCode.Mouse1,
        KeyCode.Mouse2,
        KeyCode.Mouse3,
        KeyCode.Mouse4,
        KeyCode.Mouse5,
        KeyCode.Mouse6,
    };

    private void Awake()
    {
        button.onClick.AddListener(() => {
            button.interactable = false;
            waitForKey = true;
        });
    }

    private KeyCode GetMouseButton()
    {
        foreach (var code in mouseCodes)
        {
            if (Input.GetKey(code))
                return code;
        }

        return KeyCode.None;
    }

    void OnGUI()
    {
        if (!waitForKey)
            return;

        Event e = Event.current;

        if (e == null)
            return;

        if (e.isKey || e.isMouse || Input.anyKey)
        {
            var keyCode = e.keyCode;
            var mouseButton = GetMouseButton();

            if (mouseButton != KeyCode.None)
            {
                keyCode = mouseButton;
            }

            buttonText.text = keyCode.ToString();
            
            waitForKey = false;
            button.interactable = true;
            EventSystem.current.SetSelectedGameObject(null);

            OnCode?.Invoke(this, new KeyCodeArgs { Code = keyCode });
        }
    }
}
