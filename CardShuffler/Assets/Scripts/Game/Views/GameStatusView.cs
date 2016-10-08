using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// This view keeps track of and displays the game status.
/// </summary>
public class GameStatusView : IGameView
{
    //// TODO: Game start
    //// TODO: Game in progress
    //// TODO: Game over - no more cards left in deck
    //// TODO: Game history - previous cards dealt

    private List<CardModel> previousCards;

    public override void Initialize(Presenter presenter)
    {
        previousCards = new List<CardModel>();
    }

    /// <summary>
    /// Keep track of the card deal history.
    /// </summary>
    /// <param name="msg">The most recent ard dealt.</param>
    [RecvMsgMethod]
    private void ReceiveCardDealtMsg(CardDealtMsg msg)
    {
        previousCards.Add(msg.Card);
    }
}
