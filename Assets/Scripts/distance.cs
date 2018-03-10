using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class distance : MonoBehaviour {

    public GameObject endmenu;
    public GameObject ingameDisplay;
    public Text miles;
    public int milesInt;

    public bool IsConnectedToGoogleServices;

    public void Init()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;
    }

    public bool ConnectToGoogleServices()
    {
        if (!IsConnectedToGoogleServices)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                IsConnectedToGoogleServices = success;
                Debug.Log("connected to Google Play Services");
            });
        }
        return IsConnectedToGoogleServices;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if ((coll.gameObject.tag == "enemy") || (coll.gameObject.tag == "plant"))
        {
            CharacterFinal.movementSpeed = 0f;
            endmenu.SetActive(true);
            ingameDisplay.SetActive(true);
            ConnectToGoogleServices();
            Social.ReportScore(((int)transform.position.x), "CgkIrL-D6uAHEAIQAQ", (bool success) =>
            {
                Debug.Log("score posted");
            });
        }
    }

    // Update is called once per frame
    void Update () {
        milesInt = ((int)transform.position.x);

        miles.text = milesInt.ToString();
        if (transform.position.y < -1)
        {
            Destroy(this.gameObject);
            endmenu.SetActive(true);
            ingameDisplay.SetActive(true);
        }
        
        if (milesInt>100)
        {
            Social.ReportProgress("CgkIrL-D6uAHEAIQAg", 100.0f, (bool success) => {
                // handle success or failure
            });
        }
        if (milesInt>150)
        {
            Social.ReportProgress("CgkIrL-D6uAHEAIQAw", 100.0f, (bool success) => {
                // handle success or failure
            });
        }
        if (milesInt > 250)
        {
            Social.ReportProgress("CgkIrL-D6uAHEAIQBA", 100.0f, (bool success) => {
                // handle success or failure
            });
        }
    }
}
