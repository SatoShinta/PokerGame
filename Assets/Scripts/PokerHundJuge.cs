using System.Collections.Generic;
using UnityEngine;

public class PokerHundJuge : MonoBehaviour
{
    [SerializeField] GameObject[] slots;
    [SerializeField, Header("�v���C���[�̌��݂̊G��")] public List<Sprite> _playerCardSpriteNow = new List<Sprite>();
    [SerializeField, Header("�v���C���[��card��rank")] public List<CardData.Rank> _playerRankJuge = new List<CardData.Rank>();
    [SerializeField, Header("�v���C���[��card��suit")] public List<CardData.Suit> _playerSuitJuge = new List<CardData.Suit>();

    [SerializeField, Header("�X���b�g�̊G��")] Sprite[] _slotSprite;
    [SerializeField, Header("�X���b�g��rank")] public List<CardData.Rank> _slotRankJuge = new List<CardData.Rank>();
    [SerializeField, Header("�X���b�g��suit")] public List<CardData.Suit> _slotSuitJuge = new List<CardData.Suit>();

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


}
