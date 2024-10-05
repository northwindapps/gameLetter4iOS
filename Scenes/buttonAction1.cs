using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonAction1 : MonoBehaviour
{

    void Start()
    {
        
    }

    public void OnButtonClick2()
    {
        Debug.Log("Button Clicked!");
    }

    public void SwitchScene()
    {
        Debug.Log("Switching Scene...");
        //Spinner.StartSpinner(); // Start spinning
        SceneManager.LoadScene("SampleScene");
    }
}