using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    public Dialogue dialogueInstance; 

    public void OnUsersFetched(string jsonData)
    {
        Debug.Log("Received user data: " + jsonData);
        
        // Here you can parse jsonData and do something with it
        // Example: Deserialize to a User class
        // var users = JsonUtility.FromJson<UserList>(jsonData);
        dialogueInstance.SetUserData(jsonData);
    }
}