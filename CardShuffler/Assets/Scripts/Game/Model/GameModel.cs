using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Concrete implementation of the IGameModel abstract base class.
/// </summary>
public class GameModel : IGameModel
{
    private DeckModel deckModel;

    public override void Initialize(Presenter presenter)
    {
        // Let the base class do its thing.
        base.Initialize(presenter);

        // Setup the dealer and shuffler models.
        IDealer dealer = new Dealer();
        IShuffler shuffler = new Shuffler();
        DeckConfig config = new DeckConfig();

        // Get the initial deck state.
        List<CardModel> deck = config.GetInitialDeckState();

        // Initialize the deck model.
        deckModel = new DeckModel(dealer, shuffler, deck);

        // Send the initial deck state.
        InitialDeckMsg msg = new InitialDeckMsg { Cards = deck };
        presenter.PublishMsg(msg);
    }

    /// <summary>
    /// Deal a single card.
    /// </summary>
    public void DealCard()
    {
        DealCardsMsg msg = new DealCardsMsg();
        msg.Cards = new List<CardModel>();
        msg.Cards.AddRange(deckModel.DealCards(1));

        presenter.PublishMsg(msg);
    }

    /// <summary>
    /// Reset the deck.
    /// </summary>
    public void Reset()
    {
        // Reset the deck.
        deckModel.ResetDeck();

        // Reset the views.
        ResetViewMsg resetMsg = new ResetViewMsg();
        presenter.PublishMsg(resetMsg);
    }

    /// <summary>
    /// Shuffle the deck.
    /// </summary>
    public void Shuffle()
    {
        deckModel.ShuffleDeck();
    }

    /// <summary>
    /// Send the bottom card information to the view.
    /// </summary>
    public void Peek()
    {
        CardModel bottomCard = deckModel.Peek();

        ShowBottomCardMsg msg = new ShowBottomCardMsg { Card = bottomCard };
        presenter.PublishMsg(msg);
    }
}