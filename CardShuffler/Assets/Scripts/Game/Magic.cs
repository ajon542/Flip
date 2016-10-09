using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Display some magic.
/// </summary>
public class Magic : MonoBehaviour
{
    public GameObject jokerPrefab;
    public int numberOfCards = 100;

    private List<GameObject> deck;

    /// <summary>
    /// Generate some random cards.
    /// </summary>
    public void Play()
    {
        System.Random rand = new System.Random();
        deck = new List<GameObject>();

        for (int i = 0; i < numberOfCards; ++i)
        {
            int x = rand.Next(0, 1000) - 500;
            int y = rand.Next(400, 1000);
            int z = rand.Next(0, 1000) - 500;
            int xR = rand.Next(90) - 45;

            GameObject joker = (GameObject)Instantiate(jokerPrefab, new Vector3(x / 100.0f, y / 100.0f, z / 100.0f), Quaternion.Euler(xR, xR, xR));
            joker.transform.parent = this.transform;
            deck.Add(joker);
        }
    }

    /// <summary>
    /// Cleanup the instantiated game objects.
    /// </summary>
    public void Reset()
    {
        if (deck != null)
        {
            foreach (GameObject go in deck)
            {
                Destroy(go);
            }
            deck.Clear();
        }
    }
}
