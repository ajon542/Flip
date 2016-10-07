using UnityEngine;
using System.Collections.Generic;

public class TestScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        IDealer dealer = new Dealer();
        IShuffler shuffler = new Shuffler();
        DeckConfig config = new DeckConfig();

        List<CardModel> deck = config.GetInitialDeckState();

        DeckModel deckModel = new DeckModel(dealer, shuffler, deck);

        deckModel.ShuffleDeck();

        List<CardModel> dealtCards = deckModel.DealCards(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
