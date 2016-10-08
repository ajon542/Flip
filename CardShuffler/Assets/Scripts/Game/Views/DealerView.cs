using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Handles all the dealer specific display logic.
/// </summary>
public class DealerView : IGameView
{
    private CardModel currentCard;
    private List<CardModel> cardsToDeal;
    public Deck deck;

    /// <summary>
    /// Receive the cards to deal from the GameModel.
    /// </summary>
    /// <param name="msg">The cards to deal message.</param>
    [RecvMsgMethod]
    private void ReceiveInitialDeck(InitialDeckMsg msg)
    {
        cardsToDeal = msg.Cards;

        // Create all the cards.
        foreach (CardModel card in cardsToDeal)
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
