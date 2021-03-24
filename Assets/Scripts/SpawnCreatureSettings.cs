using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCreatureData : SettingsMessageData
{
    public new int Action = 2;
    public int Creature { set; get; }
    public int Level { set; get; }
    public int Count { set; get; }
    public int Distance { set; get; }
}

public class SpawnCreatureSettings : MonoBehaviour
{
    public Dropdown creatureDropdown;
    public InputField levelInput;
    public InputField countInput;
    public InputField distanceInput;

    public SpawnCreatureData GetData()
    {
        var payload = new SpawnCreatureData();

        payload.Creature = creatureDropdown.value;
        payload.Level = int.Parse(levelInput.text);
        payload.Count = int.Parse(countInput.text);
        payload.Distance = int.Parse(distanceInput.text);

        return payload;
    }

    void Start()
    {
        creatureDropdown.ClearOptions();
        creatureDropdown.AddOptions(creatures);
    }

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
        "Greydwarf_shaman",
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
        "Skeleton_poison",
        "StoneGolem",
        "Surtling",
        "Troll",
        "Wolf",
        "Wraith"
    };
}
