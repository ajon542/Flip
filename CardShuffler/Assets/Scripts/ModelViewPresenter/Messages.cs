using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The base class for all messages.
/// </summary>
public class BaseMsg { }

/// <summary>
/// Message indicating all the cards in the deck.
/// </summary>
public class InitialDeckMsg : BaseMsg
{
    public List<CardModel> Cards { get; set; }
}

/// <summary>
/// Deal the cards sent in this message.
/// </summary>
public class DealCardsMsg : BaseMsg
{
    public List<CardModel> Cards { get; set; }
}

/// <summary>
/// Reset everything to the default state.
/// </summary>
public class ResetViewMsg : BaseMsg { }

/// <summary>
/// The DealerView will send this message to the GameStatusView
/// to notify of the card being dealt for history purposes.
/// </summary>
public class CardDealtMsg : BaseMsg
{
    public CardModel Card { get; set; }
}

/// <summary>
/// Show the bottom card in the deck.
/// </summary>
public class ShowBottomCardMsg : BaseMsg
{
    public CardModel Card { get; set; }
}




