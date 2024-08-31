using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotStopSprite : MonoBehaviour
{
    [SerializeField, Header("åªç›ÇÃäGïø")] public Sprite _slotCardSpriteNow ;
    Slot1 _slot1;

    public void Start()
    {
        _slot1 = GetComponent<Slot1>();
    }

    public void GetSlotSprite()
    {
        _slotCardSpriteNow = _slot1.nowSprite;
    }
}
