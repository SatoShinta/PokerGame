using UnityEngine;

public class PokerHundJuge : MonoBehaviour
{
    [SerializeField] GameObject[] slots;

    Sprite _playerSprite;
    [SerializeField] Sprite[] _slotSprite;
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
