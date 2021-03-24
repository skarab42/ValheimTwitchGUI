using UnityEngine;
using UnityEngine.UI;

public class RavenMessageData : SettingsMessageData
{
    public new int Action = 1;
    public int Type { set; get; }
}

public class RavenMessageSettings : MonoBehaviour
{
    public Dropdown type;

    public RavenMessageData GetData()
    {
        var payload = new RavenMessageData();

        payload.Type = type.value;

        return payload;
    }
}
