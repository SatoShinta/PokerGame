using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot1 : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    public Sprite nowSprite;
    
   // [SerializeField] Sprite[] card;
    [SerializeField, Header("�J�[�h�̏��")] public List<CardData> _cards = new List<CardData>();

    [SerializeField,Header("card�̃����N")] public CardData.Rank _cardRank;
    [SerializeField,Header("card�̃X�[�c")] public CardData.Suit _cardSuit;

    [SerializeField] private PokerHundJuge pokerHundJuge;



    public void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        nowSprite = GetComponent<Sprite>();
    }


    //�����_����sprite�icard�z��̒��ɂ�����́j�ɕύX����
    public void CangeSprite()
    {
        //�J�[�h�̊G���������_���ɑI�����A���̊G�����X���b�g�̖ڂɂ���
        int slotRandomIndex = Random.Range(0, _cards.Count);
        CardData card = _cards[slotRandomIndex];
        spriterenderer.sprite = card.sprite;
        nowSprite = spriterenderer.sprite;
        _cardRank = card.rank;
        _cardSuit = card.suit;
    }

    public void GetCardData()
    {
        pokerHundJuge._slotRankJuge.Add(_cardRank);
        pokerHundJuge._slotSuitJuge.Add(_cardSuit);
    }

    public void CangeCard()
    {
        while(true)
        {
            int counter = 0;
            int i = 0;
            i++;
            CardData card2 = _cards[i];
            spriterenderer.sprite = card2.sprite;
            nowSprite = spriterenderer.sprite;
            _cardRank = card2.rank;
            _cardSuit = card2.suit;
            if(i > 52)
            {
                i = 0;
                counter++;
            }
            if(counter >= 3)
            {
                break;
            }
        }
        
       
    }

    public void CangeCard2()
    {
        CardData card2 = _cards[3];
    }

    public void CangeCard3()
    {
        CardData card2 = _cards[0];
    }

    public void CangeCard4()
    {
        CardData card2 = _cards[0];
    }

    public void CangeCard5()
    {
        CardData card2 = _cards[0];
    }








    /*  public void CangeColor()
      {
          //�����_���ȐF�̒l�����肷��
          float r = Random.Range(0f, 1f);
          float g = Random.Range(0f, 1f);
          float b = Random.Range(0f, 1f);

          //Color�ɐ�قǐ�������������������
          Color randomColer = new Color(r, g, b);

          Renderer renderer =GetComponent<Renderer>();

          if(renderer != null)
          {
              //���̃I�u�W�F�N�g�̃J���[�������_���ȐF�ɂ���
              renderer.material.color = randomColer;
          }
          else
          {
              Debug.Log("�͂����ĂȂ�");
          }
      }*/


}
