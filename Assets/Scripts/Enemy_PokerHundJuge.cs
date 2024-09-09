using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_PokerHundJuge : MonoBehaviour
{
    [SerializeField] GameObject[] slots;
    [SerializeField, Header("プレイヤーの現在の絵柄")] public List<Sprite> _enemyCardSpriteNow = new List<Sprite>();
    [SerializeField, Header("プレイヤーのcardのrank")] public List<CardData.Rank> _enemyplayerRankJuge = new List<CardData.Rank>();
    [SerializeField, Header("プレイヤーのcardのsuit")] public List<CardData.Suit> _enemyplayerSuitJuge = new List<CardData.Suit>();

    [SerializeField, Header("スロットの絵柄")] public Sprite[] _slotSprite;
    [SerializeField, Header("スロットのrank")] public List<CardData.Rank> _slotRankJuge = new List<CardData.Rank>();
    [SerializeField, Header("スロットのsuit")] public List<CardData.Suit> _slotSuitJuge = new List<CardData.Suit>();
    [SerializeField,Header("判定するためのリスト")] List<CardData> cardDatas = CardManager._EnemyselectedCards;

    SlotStopSprite _slotStopSprite;
    Slot1 _slot1;


    private void Start()
    {
        //スロットがある分だけ配列を作る
        _slotSprite = new Sprite[slots.Length];
    }

    private void Update()
    {
        //各スロットのSlotStopSpriteを取得する
        for (int i = 0; i < slots.Length;)
        {
            _slotStopSprite = slots[i].GetComponent<SlotStopSprite>();
            _slotSprite[i] = _slotStopSprite._slotCardSpriteNow;
            i++;
        }

    }


    //役判定のメソッド
    public void Enemy_HandCheck()
    {
        //プレイヤーの持っているカードとスロットのカードをまとめる処理
        var cards = cardDatas.Select(card => new {card.rank, card.suit}).ToList();

        //RoyalFlushか判定する処理
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
            Debug.Log( "E ロイヤルストレートフラッシュ");
        }
        else if (StraitFlush()) 
        {
            Debug.Log("E ストレートフラッシュ");
        }
        else if (FourOfaKind())
        {
            Debug.Log("E フォーカード");
        }
        else if (FullHouse())
        {
            Debug.Log("E フルハウス");
        }
        else if (Flush())
        {
            Debug.Log("E フラッシュ");
        }
        else if (Straight())
        {
            Debug.Log("E ストレート");
        }
        else if (ThreeOfaKind())
        {
            Debug.Log("E スリーカード");
        }
        else if (TowPair())
        {
            Debug.Log("E ツーペア");
        }
        else if (OnePair())
        {
            Debug.Log("E ワンペア");
        }
        else
        {
            Debug.Log("E ノーペア");
        }
    }

    
    public void RemoveListsJage()
    {
        _enemyCardSpriteNow.Clear();
        _enemyplayerRankJuge.Clear();
        _enemyplayerSuitJuge.Clear();
        _slotRankJuge.Clear();
        _slotSuitJuge.Clear();
        cardDatas.Clear();
    }



}
