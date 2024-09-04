using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu]
public class CardData : ScriptableObject
{
    public Sprite sprite;
    public Rank rank;
    public Suit suit;

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Rank
    {
        Ace,    
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
    }
   
}
