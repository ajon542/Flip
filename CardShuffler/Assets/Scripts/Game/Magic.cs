using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Display some magic.
/// </summary>
public class Magic : MonoBehaviour
{
    public GameObject jokerPrefab;

    private GameObject deck;

    /// <summary>
    /// Generate some random cards.
    /// </summary>
    public void Play()
    {
        deck = (GameObject)Instantiate(jokerPrefab, new Vector3(0, 2.0f, -1.5f), Quaternion.identity);
        deck.transform.parent = this.transform;
    }

    /// <summary>
    /// Cleanup the instantiated game objects.
    /// </summary>
    public void Reset()
    {
        if (deck != null)
        {
            Destroy(deck);
        }
    }
}
