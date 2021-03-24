using UnityEngine;
using UnityEngine.UI;

public class HUDMessageData : SettingsMessageData
{
    public new int Action = 3;
    public int Position { set; get; }
}

public class HUDMessageSettings : MonoBehaviour
{
    public Dropdown positionDropdown;

    public HUDMessageData GetData()
    {
        var payload = new HUDMessageData();

        payload.Position = positionDropdown.value;

        return payload;
    }
}
