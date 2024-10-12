using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image backgroundImage;
    public string[] lines;
    private string userData;

    [DllImport("__Internal")]
    private static extern void SendMessageToJS(string message);

    [DllImport("__Internal")]
    private static extern void GetUsers();
    

    // Start is called before the first frame update
    void Start()
    {
        // Initially hide the text and background
        backgroundImage.gameObject.SetActive(false);
        textComponent.gameObject.SetActive(false);

        
        #if UNITY_WEBGL && !UNITY_EDITOR
        // This sends a message to the WebGL context
        SendMessageToJS("InitFirebase");
        GetUsers();
        #endif
    }

    // This method is called when Firebase initialization status is sent from JavaScript
    void OnFirebaseInitialized(string status)
    {
        if (status == "true")
        {
            Debug.Log("Firebase has been initialized successfully.");
            // Proceed with fetching data or any other Firebase operations
        }
        else
        {
            Debug.Log("Failed to initialize Firebase.");
            // Handle failure (e.g., retry initialization or display an error)
        }
    }
    public void SetUserData(string jsonData)
    {
        userData = jsonData;  // Set data specific to this instance
        Debug.Log("User data set in Dialogue: " + userData);
    }

    // Method to show the dialogue
    public void ShowDialogue()
    {
        backgroundImage.gameObject.SetActive(true);
        textComponent.gameObject.SetActive(true);
        textComponent.text = "Dear Reader,\n\nCongratulations!\n\nYou won.\n\nCustomize this message.\n\nBy Sender";

        // Optionally, start the dialogue text or set the first line
        if (lines.Length > 0)
        {
            textComponent.text = lines[0]; // Display the first line of the dialogue
        }

        Debug.Log("Dialogue shown.");
    }
}
