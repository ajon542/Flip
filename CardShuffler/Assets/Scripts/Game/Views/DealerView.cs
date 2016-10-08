using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Handles all the dealer specific display logic.
/// </summary>
public class DealerView : IGameView
{
    private int cardIndex;
    private List<CardModel> cardsToDeal;
    public Deck deck;

    /// <summary>
    /// Receive the cards to deal from the GameModel.
    /// </summary>
    /// <param name="msg">The cards to deal message.</param>
    [RecvMsgMethod]
    private void ReceiveCardsToDeal(CardsToDealMsg msg)
    {
        Debug.Log("ReceiveCardsToDeal");
        cardsToDeal = msg.Cards;

        // Create all the cards.
        foreach (CardModel card in cardsToDeal)
        {
            deck.CreateCard(card.RankName, card.SuitName);
        }
    }

    /// <summary>
    /// Receive the deal card message from the PlayerView.
    /// This will be received when the player is ready for the next card.
    /// </summary>
    /// <param name="msg">The deal card message.</param>
    [RecvMsgMethod]
    private void ReceiveDealCardMsg(DealCardMsg msg)
    {
        if (cardIndex < cardsToDeal.Count)
        {
            // Notify the card is being dealt.
            CardDealtMsg cardDealt = new CardDealtMsg { Card = cardsToDeal[cardIndex++] };
            PublishMsg(cardDealt);

            // Deal the card.
            deck.DealCard(cardDealt.Card.RankName, cardDealt.Card.SuitName);
            //deck.DealCard("10", "hearts");
        }
        else
        {
            Debug.Log("No more cards to deal");
        }
    }
}
