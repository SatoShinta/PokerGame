using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Card : MonoBehaviour
{
    [SerializeField, Header("�J�[�h�̈ʒu")] private GameObject[] _enemyCardPos;
    [SerializeField] private GameObject _playerCard;
    [SerializeField,Header("���������J�[�h")] List<GameObject> _enemyCards = new List<GameObject>();
    [SerializeField, Header("���݂̊G��")] public List<Sprite> _enemyCardSpriteNow = new List<Sprite>();

    [SerializeField, Header("�J�[�h�̏��")] public List<CardData> _cards = new List<CardData>();
    [SerializeField, Header("card�̃����N")] List<CardData.Rank> _cardRank = new List<CardData.Rank>();
    [SerializeField, Header("card�̃X�[�c")] List<CardData.Suit> _cardSuit = new List<CardData.Suit>();


    [SerializeField, Header("�J�[�h�̔����Ԋu")] private float _spawnInterval = 0.5f;

    SpriteRenderer spriteRenderer;

    [SerializeField] private Enemy_PokerHundJuge _enemypokerHundJuge;


    public IEnumerator SpawnCoroutine()
    {

        //_playerCardPos�Ɋi�[����Ă���I�u�W�F�N�g�����邾�����s����
        foreach (var pos in _enemyCardPos)
        {
            //_spawnInterval�̎��ԕ��������s��҂�
            yield return new WaitForSeconds(_spawnInterval);

            //��D�ɗ���G���������_���ɂ���
            int randomIndex = Random.Range(0, _cards.Count);
            CardData card = _cards[randomIndex];
            spriteRenderer.sprite = card.sprite;

            //���݂̊G������肷��
            _enemyCardSpriteNow.Add(card.sprite);
            _enemypokerHundJuge._enemyCardSpriteNow.Add(card.sprite);

            //���݂̃J�[�h�̏����擾����
            _cardRank.Add(card.rank);
            _cardSuit.Add(card.suit);
            _enemypokerHundJuge._enemyplayerRankJuge.Add(card.rank);
            _enemypokerHundJuge._enemyplayerSuitJuge.Add(card.suit);
            CardManager.AddEnemySelectedCard(card);

            //_playerCard�Ɋi�[����Ă���J�[�h��_playerCardPos�̏ꏊ�ɐ�������
            GameObject newCard = Instantiate(_playerCard, pos.transform.position, Quaternion.identity);
            _enemyCards.Add(newCard);

        }
    }

    public void RemoveList()
    {
        _cardRank.Clear();
        _cardSuit.Clear();
        _enemyCardSpriteNow.Clear();
        foreach(var card in _enemyCards)
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
    }
}