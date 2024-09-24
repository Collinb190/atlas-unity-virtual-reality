using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager360 : MonoBehaviour
{
    public GameObject[] objectsInScene;
    public FadeCanvas fadeCanvas;
    public Material videoMaterial;
    public VideoPlayer videoPlayer;
    public float fadeDuration = 1f;
    public float rewindFastForwardTime = 10f; // Amount of time to rewind/fast-forward (in seconds)

    private Material _skyMaterial;

    // Start is called before the first frame update
    void Start()
    {
        _skyMaterial = RenderSettings.skybox;
    }

    public void LoadMainMenu()
    {
        // Load the corresponding level scene
        SceneManager.LoadScene("Main");
    }

    public void LoadCantina()
    {
        // Load the corresponding level scene
        SceneManager.LoadScene("Cantina");
    }

    public void LoadCube()
    {
        // Load the corresponding level scene
        SceneManager.LoadScene("Cube");
    }

    public void LoadLivingRoom()
    {
        // Load the corresponding level scene
        SceneManager.LoadScene("LivingRoom");
    }

    public void LoadMezzanine()
    {
        // Load the corresponding level scene
        SceneManager.LoadScene("Mezzanine");
    }

    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }

    // Adjust playback speed half
    public void SetPlaybackSpeedNormal()
    {
        videoPlayer.playbackSpeed = 1.0f;
    }

    // Adjust playback speed normal
    public void SetPlaybackSpeedHalf()
    {
        videoPlayer.playbackSpeed = 0.5f;
    }

    // Adjust playback speed double
    public void SetPlaybackSpeedDouble()
    {
        videoPlayer.playbackSpeed = 2.0f;
    }

    public void ToggleLooping()
    {
        videoPlayer.isLooping = true; // Enable looping when this button is pressed
    }

    // Rewind video by a specific amount of time
    public void Rewind()
    {
        videoPlayer.time = Math.Max(videoPlayer.time - rewindFastForwardTime, 0);
    }

    // Fast-forward video by a specific amount of time
    public void FastForward()
    {
        videoPlayer.time = Math.Min(videoPlayer.time + rewindFastForwardTime, videoPlayer.length);
    }

    public void StartVideo()
    {
        StartCoroutine(FadeAndSwitchVideo(videoMaterial, videoPlayer.Play));
    }

    public void PauseVideo()
    {
        StartCoroutine(FadeAndSwitchVideo(_skyMaterial, videoPlayer.Pause));
    }

    private IEnumerator FadeAndSwitchVideo(Material targetMaterial, Action onCompleteAction)
    {
        fadeCanvas.QuickFadeIn();
        yield return new WaitForSeconds(fadeDuration);

        // Perform actions after fade in
        HideOrShowObjects(targetMaterial);
        fadeCanvas.QuickFadeOut();

        // Perform actions after fading out
        RenderSettings.skybox = targetMaterial;
        onCompleteAction.Invoke();
    }

    private void HideOrShowObjects(Material targetMaterial)
    {
        SetObjectsActive(targetMaterial.Equals(_skyMaterial));
    }

    private void SetObjectsActive(bool isActive)
    {
        foreach (GameObject obj in objectsInScene)
        {
            obj.SetActive(isActive);
        }
    }
}
