using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokerHundJuge : MonoBehaviour
{
    [SerializeField] GameObject[] slots;
    [SerializeField, Header("プレイヤーの現在の絵柄")] public List<Sprite> _playerCardSpriteNow = new List<Sprite>();
    [SerializeField, Header("プレイヤーのcardのrank")] public List<CardData.Rank> _playerRankJuge = new List<CardData.Rank>();
    [SerializeField, Header("プレイヤーのcardのsuit")] public List<CardData.Suit> _playerSuitJuge = new List<CardData.Suit>();

    [SerializeField, Header("スロットの絵柄")] public Sprite[] _slotSprite;
    [SerializeField, Header("スロットのrank")] public List<CardData.Rank> _slotRankJuge = new List<CardData.Rank>();
    [SerializeField, Header("スロットのsuit")] public List<CardData.Suit> _slotSuitJuge = new List<CardData.Suit>();
    [SerializeField] List<CardData> cardDatas = CardManager._selectedCards;

    SlotStopSprite _slotStopSprite;
    Slot1 _slot1;


    private void Start()
    {
        _slotSprite = new Sprite[slots.Length];
    }

    private void Update()
    {
        for (int i = 0; i < slots.Length;)
        {
            _slotStopSprite = slots[i].GetComponent<SlotStopSprite>();
            _slotSprite[i] = _slotStopSprite._slotCardSpriteNow;
            i++;
        }

    }



    public void HandCheck()
    {
        var cards = _slotRankJuge.Zip(_slotSuitJuge, (rank, suit) => new { Rank = rank, Suit = suit })
                    .Concat(_slotRankJuge.Zip(_slotSuitJuge, (rank, suit) => new { Rank = rank, Suit = suit })).ToList();

        bool RoyalFlush() => cards.Count(c => c.Rank >= CardData.Rank.Ten && c.Suit == cards[0].Suit) >= 5
            && cards.Select(c => (int)c.Rank).OrderBy(x => x).SequenceEqual(Enumerable.Range(10, 5));


        bool IsStraitFlush() => cards.Count(c => c.Suit == cards[0].Suit
        && (int)c.Rank >= (int)cards.Min(x => (x.Rank)) && (int)c.Rank <= (int)cards.Min(x => (x.Rank)) + 4) >= 5;


    }


    public enum HandRank
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }
}
