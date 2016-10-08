using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Concrete implementation of the IGameModel abstract base class.
/// </summary>
public class GameModel : IGameModel
{
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
        DeckModel deckModel = new DeckModel(dealer, shuffler, deck);

        // Shuffle the deck.
        deckModel.ShuffleDeck();

        // Deal 52 cards.
        List<CardModel> dealtCards = deckModel.DealCards(52);

        // Send the dealt cards to the views to handle as needed.
        CardsToDealMsg msg = new CardsToDealMsg { Cards = dealtCards };
        presenter.PublishMsg(msg);
    }

    public override void UpdateModel()
    {
        //// TODO: Casino operator could say to reset deck.
        //// TODO: Casino operator could say to shuffle deck.
    }
}