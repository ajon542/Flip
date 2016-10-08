using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Representation of a deck of card game objects.
/// </summary>
public class Deck : MonoBehaviour
{
    /// <summary>
    /// Textures used on the face of the cards.
    /// </summary>
    public List<Texture2D> cardFaceTextures;

    /// <summary>
    /// List of the card game objects.
    /// </summary>
    private List<GameObject> cardGameObjects;

    /// <summary>
    /// Create a card game object.
    /// </summary>
    /// <param name="card">The card prefab.</param>
    /// <param name="rank">The rank of the card.</param>
    /// <param name="suit">The suit of the card.</param>
    public void CreateCard(GameObject card, RankName rank, SuitName suit)
    {
        // Search through the list of textures for the matching suit and rank.
        List<Texture2D> result = cardFaceTextures.FindAll(t => t.name.Contains(rank));
        Texture2D cardTex = result.Find(t => t.name.Contains(suit));
        Debug.Log(cardTex.name);

        // Instantiate the card prefab.
        GameObject revealCard = (GameObject)Instantiate(card, new Vector3(0, 0.1f, 0), Quaternion.Euler(-90, 0, 0));
        revealCard.transform.parent = this.transform;
    }
}
