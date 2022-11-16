using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GPGSManager : MonoBehaviour
{
    private PlayGamesClientConfiguration clientConfiguration;
    public Text statusTxt;
    public Text descriptionTxt;
    public GameObject homeButtonGO;

    void Start()
    {
        ConfigurGPGS();
        SignInToGPGS(SignInInteractivity.CanPromptOnce, clientConfiguration);
    }

    internal void ConfigurGPGS()
    {
        clientConfiguration = new PlayGamesClientConfiguration.Builder().Build();
    }

    internal void SignInToGPGS(SignInInteractivity interactivity, PlayGamesClientConfiguration configuration)
    {
        configuration = clientConfiguration;
        PlayGamesPlatform.InitializeInstance(configuration);
        PlayGamesPlatform.Activate();

        PlayGamesPlatform.Instance.Authenticate(interactivity, (code) =>
        {
            statusTxt.text = "Authenticating...";
            if (code == SignInStatus.Success)
            {
                statusTxt.text = "Successfully Authenticated";
                descriptionTxt.text = "Hello " + Social.localUser.userName + "Yon have an ID of" + Social.localUser.id;
                homeButtonGO.SetActive(true);
            }
            else
            {
                statusTxt.text = "Failed to Autrhenticate";
                descriptionTxt.text = "Failed to Authenticate, reason for failure is " + code;
            }
        });
    }

    public void BasicSignInButton()
    {
        SignInToGPGS(SignInInteractivity.CanPromptAlways, clientConfiguration);
    }

    public void SignOutButton()
    {
        PlayGamesPlatform.Instance.SignOut();
        statusTxt.text = "Sign Out";
        descriptionTxt.text = "";
        homeButtonGO.SetActive(false);
    }
}
