using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Method to handle level selection
    public void TeleportMode()
    {
        SceneManager.LoadScene("Teleport");
    }

    public void SmoothMode()
    {
        SceneManager.LoadScene("Smooth");
    }
}
