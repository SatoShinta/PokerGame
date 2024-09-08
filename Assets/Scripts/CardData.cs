using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu]
public class CardData : ScriptableObject
{
    //�e�J�[�h�̏��
    public Sprite sprite;
    public Rank rank;
    public Suit suit;

    //�J�[�h�̃X�[�g
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    //�J�[�h�̃����N
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
