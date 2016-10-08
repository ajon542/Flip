using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Handles all the dealer specific display logic.
/// </summary>
public class DealerView : IGameView
{
    private CardModel currentCard;
    public Deck deck;
    public GameObject bottomCard;

    private float peekCardTime = 0f;

    private void Update()
    {
        //// TODO: Probably could do some sort of fade in / out.
        if (peekCardTime > 0.0f)
        {
            bottomCard.SetActive(true);
            peekCardTime -= Time.deltaTime;
        }
        else
        {
            bottomCard.SetActive(false);
        }
    }

    /// <summary>
    /// Receive the cards to deal from the GameModel.
    /// </summary>
    /// <param name="msg">The cards to deal message.</param>
    [RecvMsgMethod]
    private void ReceiveInitialDeck(InitialDeckMsg msg)
    {
        // Create all the cards.
        foreach (CardModel card in msg.Cards)
        {
            deck.CreateCard(card.RankName, card.SuitName);
        }
    }

    /// <summary>
    /// Deal the cards directed by the GameModel.
    /// </summary>
    /// <param name="msg">The cards to deal message.</param>
    [RecvMsgMethod]
    private void ReceiveDealCardsMsg(DealCardsMsg msg)
    {
        ResetCard();
        
        //// TODO: Extend this to more than a single card.
        currentCard = msg.Cards[0];

        // Notify other views the card is being dealt.
        CardDealtMsg cardDealt = new CardDealtMsg { Card = currentCard };
        PublishMsg(cardDealt);

        // Deal the card.
        deck.DealCard(cardDealt.Card.RankName, cardDealt.Card.SuitName);
    }

    /// <summary>
    /// Show the bottom card in the deck.
    /// </summary>
    /// <param name="msg">The message containing the bottom card info.</param>
    [RecvMsgMethod]
    private void ReceiveShowBottomCard(ShowBottomCardMsg msg)
    {
        peekCardTime = 2f;

        Image image = bottomCard.GetComponent<Image>();
        if (image != null)
        {
            //// TODO: Make sure we aren't leaking any sprites here. I suspect we are.
            Texture2D tex = deck.GetFaceTexture(msg.Card.RankName, msg.Card.SuitName);
            image.sprite = Sprite.Create(
                tex,
                new Rect(0, 0, tex.width, tex.height),
                new Vector2(0, 0));
        }
    }

    /// <summary>
    /// Reset the current card index.
    /// </summary>
    [RecvMsgMethod]
    private void ReceiveResetMsg(ResetViewMsg msg)
    {
        ResetCard();
    }

    /// <summary>
    /// Clear the card from the table.
    /// </summary>
    private void ResetCard()
    {
        if (currentCard != null)
        {
            deck.ResetCard(currentCard.RankName, currentCard.SuitName);
        }
    }
}
