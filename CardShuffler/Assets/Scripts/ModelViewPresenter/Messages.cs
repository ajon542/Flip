﻿using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The base class for all messages.
/// </summary>
public class BaseMsg
{
}

public class SampleMsg : BaseMsg
{
}

public class CardsToDealMsg : BaseMsg
{
    public List<CardModel> Cards { get; set; }
}


