using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Card : MonoBehaviour
{
    [SerializeField, Header("カードの位置")] private GameObject[] _playerCardPos;
    [SerializeField] private GameObject _playerCard;
    [SerializeField,Header("発生したカード")] List<GameObject> _playerCards = new List<GameObject>();
    [SerializeField, Header("現在の絵柄")] public List<Sprite> _playerCardSpriteNow = new List<Sprite>();

    [SerializeField, Header("カードの情報")] public List<CardData> _cards = new List<CardData>();
    [SerializeField, Header("cardのランク")] List<CardData.Rank> _cardRank = new List<CardData.Rank>();
    [SerializeField, Header("cardのスーツ")] List<CardData.Suit> _cardSuit = new List<CardData.Suit>();


    [SerializeField, Header("カードの発生間隔")] private float _spawnInterval = 0.5f;

    SpriteRenderer spriteRenderer;

    [SerializeField] private PokerHundJuge pokerHundJuge;


    public IEnumerator SpawnCoroutine()
    {

        //_playerCardPosに格納されているオブジェクトがあるだけ実行する
        foreach (var pos in _playerCardPos)
        {
            //_spawnIntervalの時間分だけ実行を待つ
            yield return new WaitForSeconds(_spawnInterval);

            //手札に来る絵柄をランダムにする
            int randomIndex = Random.Range(0, _cards.Count);
            CardData card = _cards[randomIndex];
            spriteRenderer.sprite = card.sprite;

            //現在の絵柄を入手する
            _playerCardSpriteNow.Add(card.sprite);
            pokerHundJuge._playerCardSpriteNow.Add(card.sprite);

            //現在のカードの情報を取得する
            _cardRank.Add(card.rank);
            _cardSuit.Add(card.suit);
            pokerHundJuge._playerRankJuge.Add(card.rank);
            pokerHundJuge._playerSuitJuge.Add(card.suit);
            CardManager.AddSelectedCard(card);

            //_playerCardに格納されているカードを_playerCardPosの場所に生成する
            GameObject newCard = Instantiate(_playerCard, pos.transform.position, Quaternion.identity);
            _playerCards.Add(newCard);

        }
    }

    public void RemoveList()
    {
        _cardRank.Clear();
        _cardSuit.Clear();
        _playerCardSpriteNow.Clear();
        foreach(var card in _playerCards)
        {
            Destroy(card);
        }
        _playerCards.Clear();
    }

    private void Start()
    {
        spriteRenderer = _playerCard.GetComponent<SpriteRenderer>();
        //ゲーム開始時に実行
        StartCoroutine(SpawnCoroutine());
    }
}