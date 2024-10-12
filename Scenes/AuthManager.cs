using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System;


public class AuthManager : MonoBehaviour
{
    //Start is called before the first frame update
    //Login variables
    // [Header("Login")]
    // public TMP_InputField emailLoginField;
    // public TMP_InputField passwordLoginField;
    // public TMP_Text warningLoginText;
    // public TMP_Text confirmLoginText;

    //Register variables
    [Header("Register")]
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField messageField;
    public TMP_Text warningRegisterText;
    public TMP_Text confirmRegisterText;

    [DllImport("__Internal")]
    private static extern void AddUser(string email, string password, string message);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()  // Must have no parameters
    {
        Debug.Log("Button clicked!");
    }

    public void Register(){
        StartCoroutine(RegisterAsync(emailRegisterField.text,passwordRegisterField.text, messageField.text));
    }

    // This is the async method where the registration logic happens
    private IEnumerator RegisterAsync(string email,string password, string message)
    {
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

                // User is registered, handle success
                warningRegisterText.text = ""; // Clear the warning text
                confirmRegisterText.text = "Registration Successful!";
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
