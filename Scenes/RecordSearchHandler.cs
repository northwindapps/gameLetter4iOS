using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordSearchHandler : MonoBehaviour
{
    private AuthManager authManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUsersFetched(string jsonData)
    {
        Debug.Log("Received user data: " + jsonData);
        UserData userData = JsonUtility.FromJson<UserData>(jsonData);

        // Extract the message
        string message = userData.message;

        // Storing data
        PlayerPrefs.SetString("message", message);
        PlayerPrefs.Save(); 

        // Load the new scene
        SceneManager.LoadScene("LoadingScene");
    }
    public void OnUserCreated(string url)
    {
        // Find the AuthManager in the scene
        authManager = FindObjectOfType<AuthManager>();
        authManager.outputField.gameObject.SetActive(true);
        Debug.Log("Unity Debug: Created user url: " + url);
       
        authManager.outputField.text = url.ToString();
        authManager.warningRegisterText.text = "Use the following url to play the game";
    }
}

[System.Serializable] // Make sure to mark the class as Serializable
public class UserData
{
    public string email;
    public string message;
    public string password;
    public long timestamp; // Use long for timestamp
}
