using UnityEngine;
using UnityEngine.EventSystems;

public class RewardButton : MonoBehaviour, IPointerClickHandler
{
    public RewardGridItem reward;
    public RewardSettings rewardSettings;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Reward -> {reward.id}");

        rewardSettings.SetReward(reward);
        rewardSettings.SetActive(true);
    }
}
