using UnityEngine;
using System.Collections;

public class DealerView : IGameView
{
    private void Update()
    {
    }

    [RecvMsgMethod]
    private void ReceiveCardsToDeal(CardsToDealMsg msg)
    {
        Debug.Log("ReceiveCardsToDeal");
    }
}
