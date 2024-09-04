using System.Collections.Generic;
using UnityEngine;

public class PokerHundJuge : MonoBehaviour
{
    [SerializeField] GameObject[] slots;
    [SerializeField, Header("プレイヤーの現在の絵柄")] public List<Sprite> _playerCardSpriteNow = new List<Sprite>();
    [SerializeField, Header("スロットの絵柄")] Sprite[] _slotSprite;

    [SerializeField, Header("スロットのrank")] List<CardData.Rank> _cardRankJuge = new List<CardData.Rank>();
    [SerializeField, Header("スロットのsuit")] List<CardData.Suit> _cardSuitJuge = new List<CardData.Suit>();

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

            _slot1 = slots[i].GetComponent<Slot1>();
            i++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _cardRankJuge.Add(_slot1._cardRank);
            _cardSuitJuge.Add(_slot1._cardSuit);
        }


    }


}
