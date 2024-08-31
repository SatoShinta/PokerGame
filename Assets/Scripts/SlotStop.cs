using System.Collections.Generic;
using UnityEngine;

public class SlotStop : MonoBehaviour
{
    [SerializeField, Header("スロット")] GameObject[] slots;
    [SerializeField, Header("現在の絵柄")] public List<Sprite> _playerCardSpriteNow = new List<Sprite>();
    public Animator[] slotAnimator;
    public int pushCounter;

    Slot1 slot1;
   [SerializeField] SlotStopSprite[] SSS;

    void Start()
    {
        slot1 = GetComponent<Slot1>();
        SSS = GetComponents<SlotStopSprite>();

        //slotsの中にあるオブジェクトの分の配列を作成
        slotAnimator = new Animator[slots.Length];

        //slotsがある分for文を回す（配列の中にあるオブジェクトのアニメーターを取得）
        for (int i = 0; i < slots.Length; i++)
        {
            slotAnimator[i] = slots[i].GetComponent<Animator>();
        }
        //pushCounterの初期化
        pushCounter = 0;
    }

    void Update()
    {
        //スペースキーが押されたとき、
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (SlotStopSprite sss in SSS)
            {
                _playerCardSpriteNow.Add(sss._slotCardSpriteNow);
            }
            //pushCounterを＋１し、
            pushCounter++;

            //回数ごとに各スロットのアニメーションを再生する
            switch (pushCounter)
            {
                case 1:
                    slotAnimator[0].Play("stop1");
                    break;
                case 2:
                    slotAnimator[1].Play("stop2");
                    break;
                case 3:
                    slotAnimator[2].Play("stop3");
                    break;
                case 4:
                    slotAnimator[3].Play("stop4");
                    break;
                case 5:
                    slotAnimator[4].Play("stop5");
                    break;
            }
        }

    }



}