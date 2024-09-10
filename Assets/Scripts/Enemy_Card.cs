using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_Card : MonoBehaviour
{
    [SerializeField, Header("�J�[�h�̈ʒu")] private GameObject[] _enemyCardPos;
    [SerializeField] private GameObject _playerCard;
    [SerializeField, Header("���������J�[�h")] List<GameObject> _enemyCards = new List<GameObject>();
    [SerializeField, Header("���݂̊G��")] public List<Sprite> _enemyCardSpriteNow = new List<Sprite>();

    [SerializeField, Header("�J�[�h�̏��")] public List<CardData> _cards = new List<CardData>();
    [SerializeField, Header("card�̃����N")] List<CardData.Rank> _cardRank = new List<CardData.Rank>();
    [SerializeField, Header("card�̃X�[�c")] List<CardData.Suit> _cardSuit = new List<CardData.Suit>();
    //HashSet<CardData> EtukattaCard = new HashSet<CardData>();


    [SerializeField, Header("�J�[�h�̔����Ԋu")] private float _spawnInterval = 0.5f;

    SpriteRenderer spriteRenderer;

    [SerializeField] private Enemy_PokerHundJuge _enemypokerHundJuge;

    [SerializeField] private List<Slot1> slot1scripts = new List<Slot1>();

    CardData _cardData;


    public IEnumerator SpawnCoroutine()
    {

        //_playerCardPos�Ɋi�[����Ă���I�u�W�F�N�g�����邾�����s����
        foreach (var pos in _enemyCardPos)
        {
            //_spawnInterval�̎��ԕ��������s��҂�
            yield return new WaitForSeconds(_spawnInterval);

            do
            {
                int randomIndex = Random.Range(0, _cards.Count);
                _cardData = _cards[randomIndex];
            } while (Slot1._serectedCards.Contains(_cardData));
            //��D�ɗ���G���������_���ɂ���
            
            Slot1._serectedCards.Add(_cardData);

            spriteRenderer.sprite = _cardData.sprite;


            //���݂̊G������肷��
            _enemyCardSpriteNow.Add(_cardData.sprite);
            _enemypokerHundJuge._enemyCardSpriteNow.Add(_cardData.sprite);

            //���݂̃J�[�h�̏����擾����
            _cardRank.Add(_cardData.rank);
            _cardSuit.Add(_cardData.suit);
            _enemypokerHundJuge._enemyplayerRankJuge.Add(_cardData.rank);
            _enemypokerHundJuge._enemyplayerSuitJuge.Add(_cardData.suit);
            CardManager.AddEnemySelectedCard(_cardData);
            foreach (var slot1 in slot1scripts)
            {
                slot1.AddDataHash(_cardData);
            }

            //_playerCard�Ɋi�[����Ă���J�[�h��_playerCardPos�̏ꏊ�ɐ�������
            GameObject newCard = Instantiate(_playerCard, pos.transform.position, Quaternion.identity);
            _enemyCards.Add(newCard);

        }
        yield return new WaitForSeconds(0.5f);

    }

    public void RemoveList()
    {
        _cardRank.Clear();
        _cardSuit.Clear();
        _enemyCardSpriteNow.Clear();
        foreach (var card in _enemyCards)
        {
            Destroy(card);
        }
        _enemyCards.Clear();
    }

    private void Start()
    {
        spriteRenderer = _playerCard.GetComponent<SpriteRenderer>();
        //�Q�[���J�n���Ɏ��s
        StartCoroutine(SpawnCoroutine());
        slot1scripts = FindObjectsOfType<Slot1>().ToList();
    }
}