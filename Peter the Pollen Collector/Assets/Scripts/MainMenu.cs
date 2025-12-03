using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;   // panel with Play / Options / Quit buttons
    public GameObject optionsPanel;    // panel with your Back button

    [Header("Scene To Load")]
    public string gameSceneName = "GameScene"; // change if your level has a different name

    private void Start()
    {
        // Start on the main menu, hide options
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        if (optionsPanel != null) optionsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        Debug.Log("PLAY GAME");
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenOptions()
    {
        Debug.Log("OPEN OPTIONS");
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (optionsPanel != null) optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        Debug.Log("CLOSE OPTIONS");
        if (optionsPanel != null) optionsPanel.SetActive(false);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
}
