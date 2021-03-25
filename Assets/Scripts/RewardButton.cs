using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RewardButton : MonoBehaviour, IPointerClickHandler
{
    public Image image;
    public RewardGridItem reward;
    public RewardSettings rewardSettings;

    public void OnPointerClick(PointerEventData eventData)
    {
        rewardSettings.SetReward(reward);
    }
}
