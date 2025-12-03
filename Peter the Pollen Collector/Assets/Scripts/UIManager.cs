using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;

    public void OpenOptions()
    {
        Debug.Log("OpenOptions() called!");
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        Debug.Log("CloseOptions() called!");
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
