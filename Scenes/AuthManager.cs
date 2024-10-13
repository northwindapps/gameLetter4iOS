using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System;


public class AuthManager : MonoBehaviour
{
    //Register variables
    [Header("Register")]
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField messageField;
    public TMP_InputField outputField;
    public TMP_Text warningRegisterText;
    public TMP_Text confirmRegisterText;

    [DllImport("__Internal")]
    private static extern void AddUser(string email, string password, string message);

    [DllImport("__Internal")]
    private static extern void FindRecord();

    private DateTime lastAttemptTime = DateTime.MinValue;  // To store the time of the last attempt
    private const float delayBetweenAttempts = 60f;  // Delay in seconds (e.g., 1 minute)


    void Start()
    {
        warningRegisterText.text = "";
        confirmRegisterText.text = "";
        messageField.text = "";
        outputField.gameObject.SetActive(false);
        
        #if UNITY_WEBGL && !UNITY_EDITOR
        FindRecord();
        #endif
                        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()  // Must have no parameters
    {
        Debug.Log("Button clicked!");
    }

    public void OnCopyButtonClick()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
        // Copy the text from the input field to the clipboard
        Application.ExternalCall("CopyTextToClipboard", outputField.text);
        Debug.Log("Text copied to clipboard: " + outputField.text);
        #endif
    }

    public void Register(){
        StartCoroutine(RegisterAsync(emailRegisterField.text,passwordRegisterField.text, messageField.text));
    }

    // This is the async method where the registration logic happens
    private IEnumerator RegisterAsync(string email,string password, string message)
    {
        // Calculate the time since the last attempt
        float secondsSinceLastAttempt = (float)(DateTime.UtcNow - lastAttemptTime).TotalSeconds;

        // Check if the user needs to wait before trying again
        if (secondsSinceLastAttempt < delayBetweenAttempts)
        {
            warningRegisterText.text = $"Please wait {delayBetweenAttempts - secondsSinceLastAttempt:F0} seconds before trying again.";
            yield break;  // Exit the coroutine early if the delay hasn't passed
        }
        
        if (string.IsNullOrEmpty(emailRegisterField.text) ||string.IsNullOrEmpty(passwordRegisterField.text) || string.IsNullOrEmpty(messageField.text))
        {
            // Show a warning if password or message is empty
            warningRegisterText.text = "Email or Password or message is empty!";
        }
        else
        {
            try
            {
                #if UNITY_WEBGL && !UNITY_EDITOR
                AddUser(email,password,message);
                #endif
            }
            catch (Exception ex)
            {
                // Handle any general exception
                Debug.LogError("An unexpected error occurred: " + ex.Message);
            }
        }
        yield return null;
    }
}
