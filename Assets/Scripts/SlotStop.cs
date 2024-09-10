using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using static CardData;

public class SlotStop : MonoBehaviour
{
    [SerializeField, Header("�X���b�g")] GameObject[] slots;
    public Animator[] slotAnimator;
    public Animator betAnimater;
    public int pushCounter;
    public int tarnCounter;
    [SerializeField] PokerHundJuge PokerHundJuge;
    [SerializeField] Enemy_PokerHundJuge EnemyHundJuge;
    [SerializeField] Player_Card Player_Card;
    [SerializeField] Enemy_Card Enemy_Card;
    [SerializeField] ChipManager ChipManager;
    [SerializeField] PlayableDirector timeline;
    [SerializeField] PlayableDirector gameEnd;
    [SerializeField] FlagManagement FlagManagement;
    [SerializeField] GameObject[] CardBuck;

    

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
        if (Player_Card._cardOk == true && FlagManagement.slotStart == false)
        {
            //�X�y�[�X�L�[�������ꂽ�Ƃ��A
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(ChipManager._betChips == false)
                {
                    //pushCounter���{�P���A
                    pushCounter++;

                    //�񐔂��ƂɊe�X���b�g�̃A�j���[�V�������Đ�����
                    switch (pushCounter)
                    {
                        case 1:
                            StartCoroutine(SlotAnim1());
                            ChipManager._betChips = true;
                            break;
                        case 2:
                            slotAnimator[3].Play("stop4");
                            break;
                        case 3:
                            slotAnimator[4].Play("stop5");
                            foreach( var cards  in CardBuck)
                            {
                                cards.SetActive(false);
                            }
                            break;
                        case 4:
                            PokerHundJuge.GetHandRank();
                            PokerHundJuge.HandCheck();
                            EnemyHundJuge.Enemy_GetHandRank();

                            EnemyHundJuge.Enemy_HandCheck();
                            timeline.Play();
                            PokerHundJuge.CompareHands();
                            break;
                        case 5:
                            foreach (var card in CardBuck)
                            {
                                card.SetActive(true);
                            }
                            Player_Card.RemoveList();
                            Enemy_Card.RemoveList();
                            PokerHundJuge.RemoveListsJage();
                            EnemyHundJuge.RemoveListsJage();
                            StartCoroutine(Player_Card.SpawnCoroutine());
                            StartCoroutine(Enemy_Card.SpawnCoroutine());
                            if (ChipManager._maxPlayerChip == 0 || ChipManager._maxEnemyChip == 0)
                            {
                                WinnerCheck();
                                UnityEngine.Debug.Log("end");
                                break;
                            }
                            break;
                        case 6:
                            if (tarnCounter == 5)
                            {
                                WinnerCheck();
                                UnityEngine.Debug.Log("end");
                            }
                            slotAnimator[0].Play("slot1");
                            slotAnimator[1].Play("slot2");
                            slotAnimator[2].Play("slot3");
                            slotAnimator[3].Play("slot4");
                            slotAnimator[4].Play("slot5");
                            // StartCoroutine(Player_Card.SpawnCoroutine());
                            // StartCoroutine(Enemy_Card.SpawnCoroutine());
                            pushCounter = 0;
                            tarnCounter++;
                            break;
                    }
               

                }
            }
        }

       
    }

    public IEnumerator SlotAnim1()
    {
        yield return new WaitForSeconds(0.2f); 
        slotAnimator[0].Play("stop1");
        yield return new WaitForSeconds(0.2f);
        slotAnimator[1].Play("stop2");
        yield return new WaitForSeconds(0.2f);
        slotAnimator[2].Play("stop3");
        yield return new WaitForSeconds(0.2f);
        betAnimater.Play("PBetTextUp");
    }

    public void WinnerCheck()
    {
        bool playerWin = ChipManager.ConpareChip();
        if(playerWin)
        {
            PokerHundJuge.WinLose.text= ("Player Win");
            gameEnd.Play();
        }
        else
        {
            PokerHundJuge.WinLose.text = ("Enemy Win");
            gameEnd.Play();
        }
    }


}