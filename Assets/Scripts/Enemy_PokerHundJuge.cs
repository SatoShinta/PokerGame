using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_PokerHundJuge : MonoBehaviour
{
    [SerializeField] GameObject[] slots;
    [SerializeField, Header("�v���C���[�̌��݂̊G��")] public List<Sprite> _enemyCardSpriteNow = new List<Sprite>();
    [SerializeField, Header("�v���C���[��card��rank")] public List<CardData.Rank> _enemyplayerRankJuge = new List<CardData.Rank>();
    [SerializeField, Header("�v���C���[��card��suit")] public List<CardData.Suit> _enemyplayerSuitJuge = new List<CardData.Suit>();

    [SerializeField, Header("�X���b�g�̊G��")] public Sprite[] _slotSprite;
    [SerializeField, Header("�X���b�g��rank")] public List<CardData.Rank> _slotRankJuge = new List<CardData.Rank>();
    [SerializeField, Header("�X���b�g��suit")] public List<CardData.Suit> _slotSuitJuge = new List<CardData.Suit>();
    [SerializeField, Header("���肷�邽�߂̃��X�g")] public List<CardData> enemyCardDatas = CardManager._EnemyselectedCards;
    [SerializeField] public Text HundText;


    SlotStopSprite _slotStopSprite;
    Slot1 _slot1;


    private void Start()
    {
        //�X���b�g�����镪�����z������
        _slotSprite = new Sprite[slots.Length];
    }

    private void Update()
    {
        //�e�X���b�g��SlotStopSprite���擾����
        for (int i = 0; i < slots.Length;)
        {
            _slotStopSprite = slots[i].GetComponent<SlotStopSprite>();
            _slotSprite[i] = _slotStopSprite._slotCardSpriteNow;
            i++;
        }

    }


    //�𔻒�̃��\�b�h
    public HandRank Enemy_GetHandRank()
    {
        //�v���C���[�̎����Ă���J�[�h�ƃX���b�g�̃J�[�h���܂Ƃ߂鏈��
        var cards = enemyCardDatas.Select(card => new { card.rank, card.suit }).ToList();

        //RoyalFlush�����肷�鏈��
        bool RoyalFlush() => cards.Where(c => c.rank >= CardData.Rank.Ten && c.suit == cards[0].suit)
                                .OrderBy(c => (int)c.rank)
                                .Take(5)
                                .Select(c => (int)c.rank)
                                .SequenceEqual(Enumerable.Range(10, 5));

        bool StraitFlush() => cards.Where(c => c.suit == cards[0].suit
                                && (int)c.rank >= (int)cards.Min(x => (x.rank))
                                && (int)c.rank <= (int)cards.Min(x => (x.rank)) + 4)
                               .Count() >= 5;

        bool FullHouse() => cards.GroupBy(c => c.rank)
                           .Select(g => g.Count())
                           .OrderByDescending(x => x)
                           .Take(2)
                           .SequenceEqual(new[] { 3, 2 });

        bool Flush() => cards.GroupBy(g => g.suit).Any(g => g.Count() >= 5);

        bool Straight() => cards.Select(c => (int)c.rank)
                          .OrderBy(x => x)
                          .Distinct()
                          .Count(x => Enumerable.Range(x, 5).All(rank => cards.Any(c => (int)c.rank == rank))) >= 5;

        bool FourOfaKind() => cards.GroupBy(card => card.rank)
                            .Any(g => g.Count() >= 4);

        bool ThreeOfaKind() => cards.GroupBy(c => c.rank)
                              .Any(g => g.Count() >= 3);

        bool TowPair() => cards.GroupBy(c => c.rank)
                         .Select(g => g.Count())
                         .OrderByDescending(x => x)
                         .Take(2)
                         .SequenceEqual(new[] { 2, 2 });

        bool OnePair() => cards.GroupBy(c => c.rank)
                         .Any(g => g.Count() == 2);


        if (RoyalFlush())
        {
            return HandRank.RoyalFlush;
        }
        else if (StraitFlush())
        {
            return HandRank.StraightFlush;
        }
        else if (FourOfaKind())
        {
            return HandRank.FourOfAKind;
        }
        else if (FullHouse())
        {
            return HandRank.FullHouse;
        }
        else if (Flush())
        {
            return HandRank.Flush;
        }
        else if (Straight())
        {
            return HandRank.Straight;
        }
        else if (ThreeOfaKind())
        {
            return HandRank.ThreeOfAKind;
        }
        else if (TowPair())
        {
            return HandRank.TwoPair;
        }
        else if (OnePair())
        {
            return HandRank.OnePair;
        }
        else
        {
            return HandRank.HighCard;
        }
    }

    public void Enemy_HandCheck()
    {


        HandRank rank = Enemy_GetHandRank();
        switch (rank)
        {
            case HandRank.RoyalFlush:
                HundText.text = "���C�����X�g���[�g�t���b�V��";
                break;
            case HandRank.StraightFlush:
                HundText.text = ("�X�g���[�g�t���b�V��");
                break;
            case HandRank.FourOfAKind:
                HundText.text = ("�t�H�[�J�[�h");
                break;
            case HandRank.FullHouse:
                HundText.text = ("�t���n�E�X");
                break;
            case HandRank.Flush:
                HundText.text = ("�t���b�V��");
                break;
            case HandRank.Straight:
                HundText.text = ("�X�g���[�g");
                break;
            case HandRank.ThreeOfAKind:
                HundText.text = ("�X���[�J�[�h");
                break;
            case HandRank.TwoPair:
                HundText.text = ("�c�[�y�A");
                break;
            case HandRank.OnePair:
                HundText.text = ("�����y�A");
                break;
            default:
                HundText.text = ("�n�C�J�[�h");
                break;
        }
    }


    public void RemoveListsJage()
    {
        _enemyCardSpriteNow.Clear();
        _enemyplayerRankJuge.Clear();
        _enemyplayerSuitJuge.Clear();
        _slotRankJuge.Clear();
        _slotSuitJuge.Clear();
        enemyCardDatas.Clear();
    }


    public enum HandRank : int
    {
        RoyalFlush = 10,
        StraightFlush = 9,
        FourOfAKind = 8,
        FullHouse = 7,
        Flush = 6,
        Straight = 5,
        ThreeOfAKind = 4,
        TwoPair = 3,
        OnePair = 2,
        HighCard = 1
    }


}
