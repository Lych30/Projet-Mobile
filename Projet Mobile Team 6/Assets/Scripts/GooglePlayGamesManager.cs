using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using Pathfinding;

namespace Pathfinding
{
    public class GooglePlayGamesManager : MonoBehaviour
    {
        public bool IsConnectedToGPS;
        GooglePlayGamesManager instance;
        private void Awake()
        {
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();

        }
        // Start is called before the first frame update
        void Start()
        {
            instance = this;
            SignInGPS();
            if (IsConnectedToGPS)
            {
                Social.ReportProgress(GPGSIds.achievement_welcome_home, 100.0f, null);
            }

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
    }
}
