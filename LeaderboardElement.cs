using UnityEngine;
using UnityEngine.UI;

public class LeaderboardElement : MonoBehaviour
{
    public GameObject rankImage;
    public Text rankText;
    public Text userNameText;
    public Text levelNumberText;

    public void LeaderboardElementSetup(int _rank, string _userName, int _levelNumber)
    {
        if (_rank == 1)
            rankImage.SetActive(true);
        else
            rankImage.SetActive(false);

        rankText.text = _rank.ToString();
        userNameText.text = _userName.ToUpper();
        levelNumberText.text = _levelNumber.ToString();
    }
}
