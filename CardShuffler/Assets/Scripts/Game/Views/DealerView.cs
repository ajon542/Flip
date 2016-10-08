using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Handles all the dealer specific display logic.
/// </summary>
public class DealerView : IGameView
{
    private int currentCardIndex;
    private List<CardModel> cardsToDeal;
    public Deck deck;

    private void Update()
    {
        //// TODO: Make this a button
        // Deal a card.
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentCardIndex < cardsToDeal.Count)
            {
                // Remove the card from the table.
                if (currentCardIndex > 0)
                {
                    //// TODO: This is average, fix it...
                    CardModel currentCard = cardsToDeal[currentCardIndex - 1];
                    deck.ResetCard(currentCard.RankName, currentCard.SuitName);
                }

                // Notify other views the card is being dealt.
                CardDealtMsg cardDealt = new CardDealtMsg { Card = cardsToDeal[currentCardIndex++] };
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
    /// Reset the current card index.
    /// </summary>
    [RecvMsgMethod]
    private void ReceiveResetMsg(ResetViewMsg msg)
    {
        // Remove the card from the table.
        if (currentCardIndex > 0)
        {
            //// TODO: This is average, fix it...
            CardModel currentCard = cardsToDeal[currentCardIndex - 1];
            deck.ResetCard(currentCard.RankName, currentCard.SuitName);
        }

        currentCardIndex = 0;
    }
}
