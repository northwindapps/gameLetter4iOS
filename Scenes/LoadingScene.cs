using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Spinner1;

    void Start()
    {
        Spinner1.SetActive(true);
        SceneManager.LoadScene("SampleScene");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
