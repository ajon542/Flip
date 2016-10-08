using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// This view keeps track of and displays the game status.
/// </summary>
public class HistoryView : IGameView
{
    //// TODO: Game start
    //// TODO: Game in progress
    //// TODO: Game over - no more cards left in deck
    //// TODO: Game history - previous cards dealt


    /// <summary>
    /// This provides the parent object to be able to attach the runtime generated inventory list.
    /// </summary>
    [SerializeField]
    private GameObject inventoryListParent;

    /// <summary>
    /// The button prefab to be generated. This represents a single item in the store.
    /// </summary>
    [SerializeField]
    private GameObject listItemPrefab;

    private List<CardModel> previousCards;

    public override void Initialize(Presenter presenter)
    {
        previousCards = new List<CardModel>();
        base.Initialize(presenter);
    }

    /// <summary>
    /// Keep track of the card deal history.
    /// </summary>
    /// <param name="msg">The most recent ard dealt.</param>
    [RecvMsgMethod]
    private void ReceiveCardDealtMsg(CardDealtMsg msg)
    {
        previousCards.Add(msg.Card);

        GameObject listItem = (GameObject)Instantiate(listItemPrefab);

        string cardName = string.Format("{0} of {1}", msg.Card.RankName, msg.Card.SuitName);

        listItem.GetComponentInChildren<Text>().text = cardName;

        listItem.transform.SetParent(inventoryListParent.transform);
    }

    /// <summary>
    /// Clear the history.
    /// </summary>
    [RecvMsgMethod]
    private void ReceiveResetMsg(ResetViewMsg msg)
    {
        previousCards.Clear();
    }
}
