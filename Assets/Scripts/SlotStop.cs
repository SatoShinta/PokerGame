using UnityEngine;

public class SlotStop : MonoBehaviour
{
    [SerializeField, Header("�X���b�g")] GameObject[] slots;
    public Animator[] slotAnimator;
    public int pushCounter;

    void Start()
    {
        //slots�̒��ɃA���I�u�W�F�N�g�̕��̔z����쐬
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
            }
        }
    }
}