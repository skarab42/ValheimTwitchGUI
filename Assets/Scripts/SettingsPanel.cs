using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    public KeyInput keyInputPrefab;
    public GameObject shortcutsList;

    //private void Awake()
    //{
    //    AddKeyInput("Prout A", KeyCode.A, Prout);
    //    AddKeyInput("Prout 1", KeyCode.Alpha1, Prout);
    //    AddKeyInput("Prout 2", KeyCode.Alpha2, Prout);
    //    AddKeyInput("Prout 3", KeyCode.Alpha3, Prout);
    //    AddKeyInput("Prout 4", KeyCode.Alpha4, Prout);
    //}

    //void Prout(object sender, KeyCodeArgs args)
    //{
    //    Debug.Log($"-> {args.Code}");
    //}

    public void AddKeyInput(string label, KeyCode code, KeyCodeHandler onCode)
    {
        var keyInput = Instantiate(keyInputPrefab, shortcutsList.transform);

        keyInput.OnCode += onCode;
        keyInput.label.text = label;
        keyInput.buttonText.text = code.ToString();
    }
}
