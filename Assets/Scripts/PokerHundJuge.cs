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
    [SerializeField, Header("���肷�邽�߂̃��X�g")] List<CardData> cardDatas = CardManager._selectedCards;

    SlotStopSprite _slotStopSprite;
    [SerializeField] private List<Slot1> slot1scripts = new List<Slot1>();


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


    //�𔻒�̃��\�b�h
    public void HandCheck()
    {
        //�v���C���[�̎����Ă���J�[�h�ƃX���b�g�̃J�[�h���܂Ƃ߂鏈��
        var cards = cardDatas.Select(card => new { card.rank, card.suit }).ToList();

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
                         .Any(g => g.Count() >= 2);


        if (RoyalFlush())
        {
            Debug.Log("���C�����X�g���[�g�t���b�V��");
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


    public void RemoveListsJage()
    {
        _playerCardSpriteNow.Clear();
        _playerRankJuge.Clear();
        _playerSuitJuge.Clear();
        _slotRankJuge.Clear();
        _slotSuitJuge.Clear();
        cardDatas.Clear();
        foreach (var slot1 in slot1scripts)
        {
            slot1.RemoveDataHash();
        }
    }



}
