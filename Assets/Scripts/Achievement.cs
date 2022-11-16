using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class Achievement : MonoBehaviour
{
    public Text logText;

    //Show the achievements
    public void ShowAchievement()
    {
        Social.ShowAchievementsUI();
    }

    //Unlock or Get the achievement
    public void DoGrantAchievement(string _achievement)
    {
        Social.ReportProgress(_achievement,
            100.00f,
            (bool success) =>
            {
                if (success)
                {
                    logText.text = _achievement + " : " + success.ToString();
                    //perform new action here on success
                }
                else
                {
                    logText.text = _achievement + " : " + success.ToString();
                }
            });
    }

    //Increment the achievement
    public void DoIncrementAchievement(string _achievement)
    {
        PlayGamesPlatform platform = (PlayGamesPlatform)Social.Active;

        platform.IncrementAchievement(_achievement,
            1,
            (bool success) =>
            {
                if (success)
                {
                    logText.text = _achievement + " : " + success.ToString();
                    //perform new action here on success
                }
                else
                {
                    logText.text = _achievement + " : " + success.ToString();
                }
            });
    }

    //Reveal the achievement
    public void DoRevealAchievement(string _achievement)
    {
        Social.ReportProgress(_achievement,
            0.0f,
            (bool success) =>
            {
                if (success)
                {
                    logText.text = _achievement + " : " + success.ToString();
                    //perform new action here on success
                }
                else
                {
                    logText.text = _achievement + " : " + success.ToString();
                }
            });
    }

    public void ListAchievement()
    {
        Social.LoadAchievements(achievements =>
        {
            logText.text = "Load Achievements" + achievements.Length;
            foreach (IAchievement item in achievements)
            {
                logText.text += "/n" + item.id + " " + item.completed;
            }
        });
    }

    public void ListDescriptions()
    {
        Social.LoadAchievementDescriptions(achievements =>
        {
            logText.text = "Load Achievements" + achievements.Length;
            foreach (IAchievementDescription item in achievements)
            {
                logText.text += "/n" + item.id + " " + item.title;
            }
        });
    }


    /* This are the methods made for achievement buttons */
    public void GrantAchievement()
    {
        DoGrantAchievement(GPGSIds.achievement_unlock_achievement);
    }

    public void IncrementAchievement()
    {
        DoIncrementAchievement(GPGSIds.achievement_increment_achievement);
    }

    public void RevealAchievement()
    {
        DoRevealAchievement(GPGSIds.achievement_hidden_unlock_achievement);
    }

    public void RevealIncrement()
    {
        DoRevealAchievement(GPGSIds.achievement_hidden_increment_achievement);
    }

    public void GrantHiddenAchievement()
    {
        DoGrantAchievement(GPGSIds.achievement_hidden_unlock_achievement);
    }

    public void HiddenIncrementAchievement()
    {
        DoIncrementAchievement(GPGSIds.achievement_hidden_increment_achievement);
    }
}
