using System.Collections.Generic;
using UnityEngine;

public class PokerHundJuge : MonoBehaviour
{
    [SerializeField] GameObject[] slots;
    [SerializeField, Header("���݂̊G��")] public List<Sprite> _playerCardSpriteNow = new List<Sprite>();
    [SerializeField, Header("�X���b�g�̊G��")] Sprite[] _slotSprite;
    [SerializeField, Header("�J�[�h�̏��")] private List<CardData> _cards = new List<CardData>();

    SlotStopSprite _slotStopSprite;


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
