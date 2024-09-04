using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Card")]
public class CardData : ScriptableObject
{
    public Sprite sprite;
    public int rank;
    public Suit suit;

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
   
}
