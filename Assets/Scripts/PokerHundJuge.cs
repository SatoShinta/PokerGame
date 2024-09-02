using System.Collections.Generic;
using UnityEngine;

public class PokerHundJuge : MonoBehaviour
{
    [SerializeField] GameObject[] slots;

    [SerializeField] public List<Sprite> _playerSprite = new List<Sprite>(); 
    [SerializeField] Sprite[] _slotSprite;
    SlotStopSprite _slotStopSprite;
    Player_Card _player_Card;

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
