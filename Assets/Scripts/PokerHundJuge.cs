using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokerHundJuge : MonoBehaviour
{
    [SerializeField] GameObject[] slots;
    [SerializeField, Header("�v���C���[�̌��݂̊G��")] public List<Sprite> _playerCardSpriteNow = new List<Sprite>();
    [SerializeField, Header("�v���C���[��card��rank")] public List<CardData.Rank> _playerRankJuge = new List<CardData.Rank>();
    [SerializeField, Header("�v���C���[��card��suit")] public List<CardData.Suit> _playerSuitJuge = new List<CardData.Suit>();

    [SerializeField, Header("�X���b�g�̊G��")] public Sprite[] _slotSprite;
    [SerializeField, Header("�X���b�g��rank")] public List<CardData.Rank> _slotRankJuge = new List<CardData.Rank>();
    [SerializeField, Header("�X���b�g��suit")] public List<CardData.Suit> _slotSuitJuge = new List<CardData.Suit>();
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
                    .Concat(_playerRankJuge.Zip(_playerSuitJuge, (rank, suit) => new { Rank = rank, Suit = suit })).ToList();

        bool RoyalFlush() => cards.Where(c => c.Rank >= CardData.Rank.Ten && c.Suit == cards[0].Suit)
                                .OrderBy(c => (int)c.Rank)
                                .Take(5)
                                .Select(c => (int)c.Rank)
                                .SequenceEqual(Enumerable.Range(10, 5));

        bool StraitFlush() => cards.Where(c => c.Suit == cards[0].Suit
                                && (int)c.Rank >= (int)cards.Min(x => (x.Rank))
                                && (int)c.Rank <= (int)cards.Min(x => (x.Rank)) + 4)
                               .Count() >= 5;

        bool FullHouse() => cards.GroupBy(c => c.Rank)
                           .Select(g => g.Count())
                           .OrderByDescending(x => x)
                           .Take(2)
                           .SequenceEqual(new[] { 3, 2 });

        bool Flush() => cards.GroupBy(g => g.Suit).Any(g => g.Count() >= 5);

        bool Straight() => cards.Select(c => (int)c.Rank)
                          .OrderBy(x => x)
                          .Distinct()
                          .Count(x => Enumerable.Range(x, 5).All(rank => cards.Any(c => (int)c.Rank == rank))) >= 5;

        bool FourOfaKind() => cards.GroupBy(card => card.Rank)
                            .Any(g => g.Count() >= 4);

        bool ThreeOfaKind() => cards.GroupBy(c => c.Rank)
                              .Any(g => g.Count() >= 3);

        bool TowPair() => cards.GroupBy(c => c.Rank)
                         .Select(g => g.Count())
                         .OrderByDescending(x => x)
                         .Take(2)
                         .SequenceEqual(new[] { 2, 2 });

        bool OnePair() => cards.GroupBy(c => c.Rank)
                         .Any(g => g.Count() >= 2);


        if (RoyalFlush())
        {
            Debug.Log( "���C�����X�g���[�g�t���b�V��");
        }
        else if (StraitFlush()) 
        {
            Debug.Log("�X�g���[�g�t���b�V��");
        }
        else if (FourOfaKind())
        {
            Debug.Log("�t�H�[�J�[�h");
        }
        else if (FullHouse())
        {
            Debug.Log("�t���n�E�X");
        }
        else if (Flush())
        {
            Debug.Log("�t���b�V��");
        }
        else if (Straight())
        {
            Debug.Log("�X�g���[�g");
        }
        else if (ThreeOfaKind())
        {
            Debug.Log("�X���[�J�[�h");
        }
        else if (TowPair())
        {
            Debug.Log("�c�[�y�A");
        }
        else if (OnePair())
        {
            Debug.Log("�����y�A");
        }
        else
        {
            Debug.Log("�m�[�y�A");
        }
    }

    




}
