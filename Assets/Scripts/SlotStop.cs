using UnityEngine;

public class SlotStop : MonoBehaviour
{
    [SerializeField, Header("�X���b�g")] GameObject[] slots;
    public Animator[] slotAnimator;
    public int pushCounter;
    [SerializeField]PokerHundJuge PokerHundJuge;
    [SerializeField]Enemy_PokerHundJuge EnemyHundJuge;
    [SerializeField]Player_Card Player_Card;
    [SerializeField]Enemy_Card Enemy_Card;


    void Start()
    {
       // Player_Card = GetComponent<Player_Card>();
       // PokerHundJuge = GetComponent<PokerHundJuge>();
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
                    PokerHundJuge.HandCheck();
                    EnemyHundJuge.Enemy_HandCheck();
                    break;
                case 6:
                    Player_Card.RemoveList();
                    Enemy_Card.RemoveList();
                    PokerHundJuge.RemoveListsJage();
                    EnemyHundJuge.RemoveListsJage();
                    break;
                case 7:
                    slotAnimator[0].Play("slot1");
                    slotAnimator[1].Play("slot2");
                    slotAnimator[2].Play("slot3");
                    slotAnimator[3].Play("slot4");
                    slotAnimator[4].Play("slot5");
                    StartCoroutine(Player_Card.SpawnCoroutine());
                    StartCoroutine(Enemy_Card.SpawnCoroutine());
                    pushCounter = 0;
                    break;

            }
        }

    }



}