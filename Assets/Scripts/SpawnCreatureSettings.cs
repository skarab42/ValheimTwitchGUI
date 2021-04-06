using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpawnCreatureData : SettingsMessageData
{
    public new int Action = 2;
    public int Creature { set; get; }
    public int Level { set; get; }
    public int Count { set; get; }
    public int Distance { set; get; }
    public bool Tamed { set; get; }
}

public class SpawnCreatureSettings : MessageSettings
{
    public Dropdown creatureDropdown;
    public InputField levelInput;
    public InputField countInput;
    public InputField distanceInput;
    public Toggle tamed;

    void Awake()
    {
        creatureDropdown.ClearOptions();
        creatureDropdown.AddOptions(creatures);
        creatureDropdown.onValueChanged.AddListener(OnCreatureChange);
    }

    private bool IsTameable(int index)
    {
        return !untameableCreatures.Contains(creatures[index]);
    }

    private bool IsTameable(string name)
    {
        return !untameableCreatures.Contains(name);
    }

    private void OnCreatureChange(int index)
    {
        tamed.gameObject.SetActive(IsTameable(index));
    }

    public override SettingsMessageData GetData()
    {
        var payload = new SpawnCreatureData();

        payload.Creature = creatureDropdown.value;
        payload.Level = int.Parse(levelInput.text);
        payload.Count = int.Parse(countInput.text);
        payload.Distance = int.Parse(distanceInput.text);
        payload.Tamed = IsTameable(creatureDropdown.value) && tamed.isOn;

        return payload;
    }

    public override void SetData(JToken data)
    {
        creatureDropdown.value = GetInt(data, "Creature", 0); 
        levelInput.text = GetString(data, "Level", "1");
        countInput.text = GetString(data, "Count", "1");
        distanceInput.text = GetString(data, "Distance", "100");
        tamed.isOn = GetBool(data, "Tamed", false);

        creatureDropdown.Select();
        creatureDropdown.RefreshShownValue();
    }

    public static List<string> untameableCreatures = new List<string>
    {
        "Crow",
        "Deer",
        "Fish1",
        "Fish2",
        "Fish3",
        "Fish4_cave",
        "Gull",
        "Leviathan",
        "Odin",
        "Eikthyr",
        "gd_king",
        "Bonemass",
        "Dragon",
        "GoblinKing",
    };

    public static List<string> creatures = new List<string> {
        "Blob",
        "BlobElite",
        "Boar",
        "Crow",
        "Deathsquito",
        "Deer",
        "Draugr",
        "Draugr_Elite",
        "Draugr_Ranged",
        "Fenring",
        "FireFlies",
        "Fish1",
        "Fish2",
        "Fish3",
        "Ghost",
        "Goblin",
        "GoblinArcher",
        "GoblinBrute",
        "GoblinShaman",
        "Greydwarf",
        "Greydwarf_Elite",
        "Greydwarf_Shaman",
        "Greyling",
        "Hatchling",
        "Leech",
        "Leviathan",
        "Lox",
        "Neck",
        "Seagal",
        "Serpent",
        "Skeleton",
        "Skeleton_NoArcher",
        "Skeleton_Poison",
        "StoneGolem",
        "Surtling",
        "Troll",
        "Wolf",
        "Wraith",
        "Eikthyr",
        "gd_king",
        "Bonemass",
        "Dragon",
        "GoblinKing",
    };
}
