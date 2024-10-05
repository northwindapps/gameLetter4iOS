using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image backgroundImage;
    public string[] lines;

    // Start is called before the first frame update
    void Start()
    {
        // Initially hide the text and background
        backgroundImage.gameObject.SetActive(false);
        textComponent.gameObject.SetActive(false);
    }

    // Method to show the dialogue
    public void ShowDialogue()
    {
        backgroundImage.gameObject.SetActive(true);
        textComponent.gameObject.SetActive(true);
        textComponent.text = "testing";

        // Optionally, start the dialogue text or set the first line
        if (lines.Length > 0)
        {
            textComponent.text = lines[0]; // Display the first line of the dialogue
        }

        Debug.Log("Dialogue shown.");
    }
}
