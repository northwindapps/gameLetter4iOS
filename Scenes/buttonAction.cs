using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonAction : MonoBehaviour
{
    //public GameObject Spinner1;

    void Start()
    {
        //Spinner1.SetActive(false);
    }

    public void OnButtonClick2()
    {
        Debug.Log("Button Clicked!");
    }

    public void SwitchScene()
    {
        Debug.Log("Switching Scene...");
        //Spinner1.SetActive(true);  // Show the spinner
        //Spinner.StartSpinner(); // Start spinning
        SceneManager.LoadScene("SampleScene");
    }
}