using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Representation of a deck of card game objects.
/// </summary>
public class Deck : MonoBehaviour
{
    /// <summary>
    /// The card prefab.
    /// </summary>
    public GameObject cardPrefab;

    /// <summary>
    /// Textures used on the face of the cards.
    /// </summary>
    public List<Texture2D> cardFaceTextures;

    /// <summary>
    /// Mapping of the card name to game objects.
    /// </summary>
    private Dictionary<string, Card> deck = new Dictionary<string, Card>();

    /// <summary>
    /// Deal a particular card from the deck.
    /// </summary>
    /// <param name="card">The card to deal.</param>
    public void DealCard(CardModel card)
    {
        string cardName = CardName(card.RankName, card.SuitName);

        SoftwareAssert.Confirm(deck.ContainsKey(cardName), "Could not find the card {0} in deck", cardName);

        deck[cardName].DealCard();
    }

    /// <summary>
    /// Discard the card.
    /// </summary>
    /// <param name="card">The card to reset.</param>
    public void ResetCard(CardModel card)
    {
        string cardName = CardName(card.RankName, card.SuitName);

        SoftwareAssert.Confirm(deck.ContainsKey(cardName), "Could not find the card {0} in deck", cardName);

        deck[cardName].ResetCard();
    }

    /// <summary>
    /// Gets the texture for the card.
    /// </summary>
    /// <param name="rank">The rank of the card.</param>
    /// <param name="suit">The suit of the card.</param>
    /// <returns>The card texture.</returns>
    public Texture2D GetFaceTexture(RankName rank, SuitName suit)
    {
        // Search through the list of textures for the matching suit and rank.
        List<Texture2D> result = cardFaceTextures.FindAll(t => t.name.Contains(rank));
        Texture2D cardTex = result.Find(t => t.name.Contains(suit));

        return cardTex;
    }

    /// <summary>
    /// Create a card game object.
    /// </summary>
    /// <param name="rank">The rank of the card.</param>
    /// <param name="suit">The suit of the card.</param>
    public void CreateCard(RankName rank, SuitName suit)
    {
        string cardName = CardName(rank, suit);

        // Don't create card if it already exists.
        if (!deck.ContainsKey(cardName))
        {
            // Get the face texture.
            Texture2D cardTex = GetFaceTexture(rank, suit);

            // Instantiate the card prefab.
            GameObject revealCard = (GameObject)Instantiate(cardPrefab, new Vector3(0, 0.1f, 0), Quaternion.Euler(-90, 0, 0));
            revealCard.transform.parent = this.transform;

            // Get the Card component.
            Card cardGameObject = (revealCard.GetComponentInChildren(typeof(Card)) as Card);
            cardGameObject.SetFaceTexture(cardTex);

            deck.Add(cardName, cardGameObject);
        }
    }

    /// <summary>
    /// Generate a card name given rank and suit.
    /// </summary>
    private string CardName(RankName rank, SuitName suit)
    {
        return string.Format("{0} of {1}", rank, suit);
    }
}
