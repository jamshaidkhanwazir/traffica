using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardScreenHandler : MonoBehaviour
{
    [Header("Leaderboard")]
    public GameObject loadingWheel;
    public Transform Content;
    public LeaderboardElement leaderboardElement;
    private LeaderboardElement[] tempElements;

    [Header("Message")]
    public GameObject messagePanel;
    public Image messageIcon;
    public Sprite errorSprite;
    public Sprite successSprite;
    public Text messageText;


    private void OnEnable()
    {
        if (tempElements != null)
        {
            foreach (var item in tempElements)
            {
                Destroy(item.gameObject);
            }
        }

        loadingWheel.SetActive(true);
        FirebaseManager.Instance.GetUsers(OnGetUsersComplete);
    }

    public void OnBackButtonClick()
    {
        UIManager.Instance.ActivateSpecificScreen(GameScreens.MainScreen);
        AudioManager.Instance.PlayButtonSound();
    }

    private void OnGetUsersComplete(List<User> userList, GetUsersResult _result)
    {
        loadingWheel.SetActive(false);
        if (_result == GetUsersResult.Successfull)
        {
            RectTransform rt = Content.gameObject.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(0, userList.Count * 55);

            userList = userList.OrderByDescending(x => x.levelNumber).ToList();
            tempElements = new LeaderboardElement[userList.Count];
            foreach (User user in userList)
            {
                LeaderboardElement tempLeaderboardElement = Instantiate(leaderboardElement);
                tempLeaderboardElement.transform.SetParent(Content);
                tempLeaderboardElement.transform.LeanScale(new Vector3(1, 1, 1), 0f);
                tempElements[userList.IndexOf(user)] = tempLeaderboardElement;

                tempLeaderboardElement.LeaderboardElementSetup((userList.IndexOf(user) + 1), user.username, user.levelNumber);
            }
        }
        else
        {
            DisplayErrorMessage("Error, try again");
        }
    }



    #region Message

    public void DisplayErrorMessage(string _message)
    {
        messagePanel.SetActive(true);
        messageIcon.GetComponent<Image>().sprite = errorSprite;
        messageText.text = _message;
        Invoke(nameof(HideMessage), 4f);
    }

    public void DisplaySuccessMessage(string _message)
    {
        messagePanel.SetActive(true);
        messageIcon.GetComponent<Image>().sprite = successSprite;
        messageText.text = _message;
        Invoke(nameof(HideMessage), 4f);
    }

    public void HideMessage()
    {
        messagePanel.SetActive(false);
    }

    #endregion
}
