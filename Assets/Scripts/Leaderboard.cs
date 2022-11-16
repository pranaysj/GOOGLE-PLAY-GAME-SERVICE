using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using GooglePlayGames;

public class Leaderboard : MonoBehaviour
{
    public Text logtxt;
    public InputField postScore;

    public void ShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }

    public void DoLeaderboardPost(int _score)
    {
        Social.ReportScore(_score, GPGSIds.leaderboard_test_leaderboard,
            (bool success) =>
            {
                if (success)
                {
                    logtxt.text = "Score Post of : " + _score;
                }
                else
                {
                    logtxt.text = "Score fail to post";
                }
            });
    }

    public void LeaderBoardPostButton()
    {
        DoLeaderboardPost(int.Parse(postScore.text));
    }
}
