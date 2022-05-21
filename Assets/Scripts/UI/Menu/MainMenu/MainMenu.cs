using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour

{
    public GameObject settingWindow;
    public string levelToload;

    public void StartGame()
    {
        SceneManager.LoadScene(1); //link in unity bettwen start and the good level
    }
    public void SettitngsButton()
    {
        settingWindow.SetActive(true);
    }
    public void CloseSettingsWindow()
    {
        settingWindow.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
