using UnityEngine;
using System.Collections;

/// <summary>
/// Handles the player interaction with the card.
/// Notifies the DealerView to deal the next card.
/// </summary>
public class PlayerView : IGameView
{
    private void Update()
    {
        //// TODO: Make this a button
        // Deal a card.
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Notify the dealer we are ready for the card to be dealt.
            DealCardMsg msg = new DealCardMsg();
            PublishMsg(msg);
        }
    }

    [RecvMsgMethod]
    private void ReceiveCardDealtMsg(CardDealtMsg msg)
    {
        Debug.Log("CardDealt: " + msg.Card);
    }
}
