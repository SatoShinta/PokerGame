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
    [SerializeField, Header("���肷�邽�߂̃��X�g")] public List<CardData> PlayerCardDatas = CardManager._selectedCards;

    SlotStopSprite _slotStopSprite;
    [SerializeField] private List<Slot1> slot1scripts = new List<Slot1>();
    [SerializeField] Enemy_PokerHundJuge Enemy_PokerHundJuge;
    [SerializeField] ChipManager chipManager;

    private void Start()
    {
        //�X���b�g�����镪�����z������
        _slotSprite = new Sprite[slots.Length];

        slot1scripts = FindObjectsOfType<Slot1>().ToList();
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


    public HandRank GetHandRank()
    {
        //�v���C���[�̎����Ă���J�[�h�ƃX���b�g�̃J�[�h���܂Ƃ߂鏈��
        var cards = PlayerCardDatas.Select(card => new { card.rank, card.suit }).ToList();

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

    public void HandCheck()
    {

        HandRank rank = GetHandRank();
        switch (rank)
        {
            case HandRank.RoyalFlush:
                Debug.Log("���C�����X�g���[�g�t���b�V��");
                break;
            case HandRank.StraightFlush:
                Debug.Log("�X�g���[�g�t���b�V��");
                break;
            case HandRank.FourOfAKind:
                Debug.Log("�t�H�[�J�[�h");
                break;
            case HandRank.FullHouse:
                Debug.Log("�t���n�E�X");
                break;
            case HandRank.Flush:
                Debug.Log("�t���b�V��");
                break;
            case HandRank.Straight:
                Debug.Log("�X�g���[�g");
                break;
            case HandRank.ThreeOfAKind:
                Debug.Log("�X���[�J�[�h");
                break;
            case HandRank.TwoPair:
                Debug.Log("�c�[�y�A");
                break;
            case HandRank.OnePair:
                Debug.Log("�����y�A");
                break;
            default:
                Debug.Log("�n�C�J�[�h");
                break;
        }
    }


    public void RemoveListsJage()
    {
        _playerCardSpriteNow.Clear();
        _playerRankJuge.Clear();
        _playerSuitJuge.Clear();
        _slotRankJuge.Clear();
        _slotSuitJuge.Clear();
        PlayerCardDatas.Clear();
        foreach (var slot1 in slot1scripts)
        {
            slot1.RemoveDataHash();
        }
    }

    public void CompareHands()
    {

        HandRank playerHandRank = GetHandRank();
        Enemy_PokerHundJuge.HandRank enemyHandRank = Enemy_PokerHundJuge.Enemy_GetHandRank();
        if ((int)playerHandRank > (int)enemyHandRank)
        {
            Debug.Log("�v���C���[Win");
            chipManager._maxPlayerChip += chipManager.eTotalAmount;
            chipManager.pTotalAmount = 0;
            chipManager.eTotalAmount = 0;
        }
        else if ((int)playerHandRank < (int)enemyHandRank)
        {
            Debug.Log("�GWin");
            chipManager._maxEnemyChip += chipManager.pTotalAmount;
            chipManager.pTotalAmount = 0;
            chipManager.eTotalAmount = 0;
        }
        else
        {
            Debug.Log("Drow");
            chipManager._maxPlayerChip += chipManager.pTotalAmount;
            chipManager._maxEnemyChip += chipManager.eTotalAmount;
            chipManager.pTotalAmount = 0;
            chipManager.eTotalAmount = 0;
        }
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
