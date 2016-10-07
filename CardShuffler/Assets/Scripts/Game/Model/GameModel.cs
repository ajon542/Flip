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
    }

    public override void UpdateModel()
    {
    }
}