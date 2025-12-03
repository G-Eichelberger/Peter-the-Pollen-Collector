using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsPanel;    // menu with Back / Controls / Credits
    public GameObject controlsPanel;   // controls screen
    public GameObject creditsPanel;    // credits screen

    private void Start()
    {
        if (optionsPanel != null) optionsPanel.SetActive(true);
        if (controlsPanel != null) controlsPanel.SetActive(false);
        if (creditsPanel != null) creditsPanel.SetActive(false);
    }

    public void OpenControls()
    {
        Debug.Log("Open Controls");
        optionsPanel.SetActive(false);
        controlsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        Debug.Log("Open Credits");
        optionsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void BackFromControls()
    {
        Debug.Log("Back from Controls");
        controlsPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void BackFromCredits()
    {
        Debug.Log("Back from Credits");
        creditsPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
}
