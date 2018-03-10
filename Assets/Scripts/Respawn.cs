using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

//This script acts as a dead zone, so when the Player hits it, the level is reloaded.
public class Respawn : MonoBehaviour
{
    public bool IsConnectedToGoogleServices;

    public void Start ()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;
        ConnectToGoogleServices();
        Debug.Log("connected to google");
    }

    public bool ConnectToGoogleServices()
    {
        if (!IsConnectedToGoogleServices)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                IsConnectedToGoogleServices = success;
                ((GooglePlayGames.PlayGamesPlatform)Social.Active).SetGravityForPopups(Gravity.BOTTOM);
            });
        }
        return IsConnectedToGoogleServices;
    }
	//This method is called when an object (with RigidBody2D and Collider2D) collides with this
	public void reloadScene()
	{
        //Reload the level (Unity scene)
        //string activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Opening");
        CharacterFinal.movementSpeed = 3f;
    }
    public void loadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }
    public void showAchievementsBoard()
    {
        if (Social.localUser.authenticated)
        {
            // show achievements UI
            Social.ShowAchievementsUI();
        }  else
        {
            ConnectToGoogleServices();
        }
    }
    public void showLeaderBoard()
    {
        if (Social.localUser.authenticated)
        {
            // show achievements UI
            Social.ShowLeaderboardUI();
        }  else
        {
            ConnectToGoogleServices();
        }
    }

}