using System.Collections.Generic;
using UnityEngine;

public class Slot1 : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    public Sprite nowSprite;

    // [SerializeField] Sprite[] card;
    [SerializeField, Header("�J�[�h�̏��")] public List<CardData> _cards = new List<CardData>();
    [SerializeField, Header("���݂�card")] public List<CardData> _nowCard = new List<CardData>();

    [SerializeField, Header("card�̃����N")] public CardData.Rank _cardRank;
    [SerializeField, Header("card�̃X�[�c")] public CardData.Suit _cardSuit;

    public static HashSet<CardData> _serectedCards = new HashSet<CardData>();
    [SerializeField] List<CardData> _selectedCardsInspecter;

    [SerializeField] private PokerHundJuge pokerHundJuge;
    CardData card;



    public void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        nowSprite = GetComponent<Sprite>();
    }

    public void Update()
    {
        _selectedCardsInspecter = new List<CardData>(_serectedCards);
    }


    //�����_����sprite�icard�z��̒��ɂ�����́j�ɕύX����
    public void CangeSprite()
    {
        //�J�[�h�̊G���������_���ɑI�����A���̊G�����X���b�g�̖ڂɂ���
        int slotRandomIndex = Random.Range(0, _cards.Count);
        card = _cards[slotRandomIndex];
        spriterenderer.sprite = card.sprite;
        nowSprite = spriterenderer.sprite;

        _cardRank = card.rank;
        _cardSuit = card.suit;
    }



    public void GetCardData()
    {
        do
        {
            int slotRandomIndex = Random.Range(0, _cards.Count);
            card = _cards[slotRandomIndex];
        } while (_serectedCards.Contains(card));

        _serectedCards.Add(card);


        spriterenderer.sprite = card.sprite;
        nowSprite = spriterenderer.sprite;
        _cardRank = card.rank;
        _cardSuit = card.suit;

        CardManager.AddSelectedCard(card);
        CardManager.AddEnemySelectedCard(card);
        pokerHundJuge._slotRankJuge.Add(_cardRank);
        pokerHundJuge._slotSuitJuge.Add(_cardSuit);

    }

    public void RemoveDataHash()
    {
        _serectedCards.Clear();
    }

    public void AddDataHash(CardData cardHash)
    {
        _serectedCards.Add(cardHash);
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
