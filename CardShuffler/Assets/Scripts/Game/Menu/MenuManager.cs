using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Start a new game.
    /// </summary>
    public void NewGame()
    {
        SceneManager.LoadScene("CardGame");
    }

    /// <summary>
    /// Provide modifiable settings to the user.
    /// </summary>
    public void Settings()
    {
        //// TODO: Provide settings for the user to modify.
    }

    /// <summary>
    /// Quit the application.
    /// </summary>
    public void Quit()
    {
        //// TODO: Quit the application.
    }
}
