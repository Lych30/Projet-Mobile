using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlayGamesManager : MonoBehaviour
{
    public bool IsConnectedToGPS;
    private void Awake()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }
    // Start is called before the first frame update
    void Start()
    {
        SignInGPS();
    }
    void SignInGPS()
    {
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) =>
        {
            switch (result)
            {
                case SignInStatus.Success:
                    IsConnectedToGPS = true;
                    break;
                default:
                    IsConnectedToGPS = false;
                    break;
            }


        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
