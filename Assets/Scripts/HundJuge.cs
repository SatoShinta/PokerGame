using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HundJuge : ScriptableObject
{




    public enum HandRank
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourCard,
        StraightFlush,
        RoyalFlush

    }
}
