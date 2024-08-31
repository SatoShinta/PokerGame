using System.Collections.Generic;
using UnityEngine;

public class SlotStop : MonoBehaviour
{
    [SerializeField, Header("�X���b�g")] GameObject[] slots;
    [SerializeField, Header("���݂̊G��")] public List<Sprite> _playerCardSpriteNow = new List<Sprite>();
    public Animator[] slotAnimator;
    public int pushCounter;

    Slot1 slot1;
   [SerializeField] SlotStopSprite[] SSS;

    void Start()
    {
        slot1 = GetComponent<Slot1>();
        SSS = GetComponents<SlotStopSprite>();

        //slots�̒��ɂ���I�u�W�F�N�g�̕��̔z����쐬
        slotAnimator = new Animator[slots.Length];

        //slots�����镪for�����񂷁i�z��̒��ɂ���I�u�W�F�N�g�̃A�j���[�^�[���擾�j
        for (int i = 0; i < slots.Length; i++)
        {
            slotAnimator[i] = slots[i].GetComponent<Animator>();
        }
        //pushCounter�̏�����
        pushCounter = 0;
    }

    void Update()
    {
        //�X�y�[�X�L�[�������ꂽ�Ƃ��A
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (SlotStopSprite sss in SSS)
            {
                _playerCardSpriteNow.Add(sss._slotCardSpriteNow);
            }
            //pushCounter���{�P���A
            pushCounter++;

            //�񐔂��ƂɊe�X���b�g�̃A�j���[�V�������Đ�����
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