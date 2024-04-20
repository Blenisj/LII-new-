using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public string sceneToLoad = "SampleScene"; // Make sure this matches the name of your boss fight scene

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure that the collider has the tag "Player"
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
