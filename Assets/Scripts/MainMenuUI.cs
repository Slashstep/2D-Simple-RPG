using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUI : MonoBehaviour
{
    public Button startGameButton;
    public Button exitGameButton;
    public InputField playerNameInput;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetPlayerName()
    {
        DataManager.Instance.playerName = playerNameInput.text;
    }
}
