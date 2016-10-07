using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Start a new game.
    /// </summary>
    public void NewGame()
    {
        Application.LoadLevel("CardGame");
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
