using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The base class for all messages.
/// </summary>
public class BaseMsg { }

/// <summary>
/// The dealer will send this message out to indicate the start
/// of a game.
/// </summary>
public class StartGameMSg : BaseMsg { }

/// <summary>
/// The dealer will send this message out to indicate the end
/// of a game.
/// </summary>
public class EndGameMsg : BaseMsg { }

/// <summary>
/// The GameModel will send this message at the start of a game
/// to notify the listeners of all the shuffled cards in the deck.
/// </summary>
public class CardsToDealMsg : BaseMsg
{
    public List<CardModel> Cards { get; set; }
}

/// <summary>
/// The PlayerView will send this message to the DealerView to
/// let them know we are ready for the card to be dealt.
/// </summary>
public class DealCardMsg : BaseMsg { }

/// <summary>
/// Reset everything to the default state.
/// </summary>
public class ResetViewMsg : BaseMsg { }

/// <summary>
/// The DealerView will send this message to the PlayerView to
/// in response to the DealCardMsg.
/// </summary>
public class CardDealtMsg : BaseMsg
{
    public CardModel Card { get; set; }
}




