using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUI : MonoBehaviour
{
    public Button startGameButton;
    public Button optionsButton;
    public Button exitGameButton;

=======

public class MainMenuUI : MonoBehaviour
{
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< Updated upstream

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
=======
>>>>>>> Stashed changes
}
