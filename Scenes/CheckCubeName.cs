using UnityEngine;

public class CheckCubeName : MonoBehaviour
{
    void Start()
    {
        // Assuming this script is attached to the cube GameObject
        Debug.Log("The name of this GameObject is: " + gameObject.name);
    }
}
