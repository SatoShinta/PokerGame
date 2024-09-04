using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Card : MonoBehaviour
{
    [SerializeField, Header("�J�[�h�̈ʒu")] private GameObject[] _playerCardPos;
    [SerializeField] private GameObject _playerCard;
    [SerializeField, Header("�J�[�h�̊G��")] private Sprite[] _playerCardSprite;
    [SerializeField, Header("���݂̊G��")] public List<Sprite> _playerCardSpriteNow = new List<Sprite>();

    [SerializeField, Header("�J�[�h�̏��")] public List<CardData> _cards = new List<CardData>();
    [SerializeField, Header("card�̃����N")] List<CardData.Rank> _cardRank = new List<CardData.Rank>();
    [SerializeField, Header("card�̃X�[�c")] List<CardData.Suit> _cardSuit = new List<CardData.Suit>();


    [SerializeField, Header("�J�[�h�̔����Ԋu")] private float _spawnInterval = 0.5f;

    SpriteRenderer spriteRenderer;
    [SerializeField] private PokerHundJuge pokerHundJuge;


    IEnumerator SpawnCoroutine()
    {

        //_playerCardPos�Ɋi�[����Ă���I�u�W�F�N�g�����邾�����s����
        foreach (var pos in _playerCardPos)
        {
            //_spawnInterval�̎��ԕ��������s��҂�
            yield return new WaitForSeconds(_spawnInterval);

            //��D�ɗ���G���������_���ɂ���
            int randomIndex = Random.Range(0, _cards.Count);
            CardData card = _cards[randomIndex];
            spriteRenderer.sprite = card.sprite;

            //���݂̊G������肷��
            _playerCardSpriteNow.Add(card.sprite);
            pokerHundJuge._playerCardSpriteNow.Add(card.sprite);
            _cardRank.Add(card.rank);
            _cardSuit.Add(card.suit);

            //_playerCard�Ɋi�[����Ă���J�[�h��_playerCardPos�̏ꏊ�ɐ�������
            Instantiate(_playerCard, pos.transform.position, Quaternion.identity);


        }
    }

    private void Start()
    {
        spriteRenderer = _playerCard.GetComponent<SpriteRenderer>();
        //�Q�[���J�n���Ɏ��s
        StartCoroutine(SpawnCoroutine());
    }
}