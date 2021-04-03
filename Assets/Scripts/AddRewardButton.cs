using UnityEngine;
using UnityEngine.UI;

public class AddRewardButton : MonoBehaviour
{
    public AddRewardForm addRewardForm;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            addRewardForm.rewardForm.ResetData();
            addRewardForm.SetActive(true);
        });
    }
}
