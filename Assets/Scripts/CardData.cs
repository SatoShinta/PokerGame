using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu]
public class CardData : ScriptableObject
{
    //各カードの情報
    public Sprite sprite;
    public Rank rank;
    public Suit suit;

    //カードのスート
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    //カードのランク
    public enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
   
}
