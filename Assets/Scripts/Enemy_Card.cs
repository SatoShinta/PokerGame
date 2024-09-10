using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_Card : MonoBehaviour
{
    [SerializeField, Header("カードの位置")] private GameObject[] _enemyCardPos;
    [SerializeField] private GameObject _playerCard;
    [SerializeField, Header("発生したカード")] List<GameObject> _enemyCards = new List<GameObject>();
    [SerializeField, Header("現在の絵柄")] public List<Sprite> _enemyCardSpriteNow = new List<Sprite>();

    [SerializeField, Header("カードの情報")] public List<CardData> _cards = new List<CardData>();
    [SerializeField, Header("cardのランク")] List<CardData.Rank> _cardRank = new List<CardData.Rank>();
    [SerializeField, Header("cardのスーツ")] List<CardData.Suit> _cardSuit = new List<CardData.Suit>();
    //HashSet<CardData> EtukattaCard = new HashSet<CardData>();


    [SerializeField, Header("カードの発生間隔")] private float _spawnInterval = 0.5f;

    SpriteRenderer spriteRenderer;

    [SerializeField] private Enemy_PokerHundJuge _enemypokerHundJuge;

    [SerializeField] private List<Slot1> slot1scripts = new List<Slot1>();

    CardData _cardData;


    public IEnumerator SpawnCoroutine()
    {

        //_playerCardPosに格納されているオブジェクトがあるだけ実行する
        foreach (var pos in _enemyCardPos)
        {
            //_spawnIntervalの時間分だけ実行を待つ
            yield return new WaitForSeconds(_spawnInterval);

            do
            {
                int randomIndex = Random.Range(0, _cards.Count);
                _cardData = _cards[randomIndex];
            } while (Slot1._serectedCards.Contains(_cardData));
            //手札に来る絵柄をランダムにする
            
            Slot1._serectedCards.Add(_cardData);

            spriteRenderer.sprite = _cardData.sprite;


            //現在の絵柄を入手する
            _enemyCardSpriteNow.Add(_cardData.sprite);
            _enemypokerHundJuge._enemyCardSpriteNow.Add(_cardData.sprite);

            //現在のカードの情報を取得する
            _cardRank.Add(_cardData.rank);
            _cardSuit.Add(_cardData.suit);
            _enemypokerHundJuge._enemyplayerRankJuge.Add(_cardData.rank);
            _enemypokerHundJuge._enemyplayerSuitJuge.Add(_cardData.suit);
            CardManager.AddEnemySelectedCard(_cardData);
            foreach (var slot1 in slot1scripts)
            {
                slot1.AddDataHash(_cardData);
            }

            //_playerCardに格納されているカードを_playerCardPosの場所に生成する
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
        //ゲーム開始時に実行
        StartCoroutine(SpawnCoroutine());
        slot1scripts = FindObjectsOfType<Slot1>().ToList();
    }
}