using System.Collections;
using UnityEngine;

public class Player_Card : MonoBehaviour
{
    [SerializeField, Header("カードの位置")] private GameObject[] _playerCardPos;
    [SerializeField] private GameObject _playerCard;
    [SerializeField, Header("カードの絵柄")] private Sprite[] _playerCardSprite;
    [SerializeField,Header("カードの発生間隔")] private float _spawnInterval = 0.5f;

    SpriteRenderer spriteRenderer;


    IEnumerator SpawnCoroutine()
    {

        //_playerCardPosに格納されているオブジェクトがあるだけ実行する
        foreach (var pos in _playerCardPos)
        {
            //_spawnIntervalの時間分だけ実行を待つ
            yield return new WaitForSeconds(_spawnInterval);

            //手札に来る絵柄をランダムにする
            int randomIndex = Random.Range(0, _playerCardSprite.Length);
            spriteRenderer.sprite = _playerCardSprite[randomIndex];

            //_playerCardに格納されているカードを_playerCardPosの場所に生成する
            Instantiate(_playerCard, pos.transform.position, Quaternion.identity);

           
        }
    }

    private void Start()
    {
        spriteRenderer = _playerCard.GetComponent<SpriteRenderer>();

        //ゲーム開始時に実行
        StartCoroutine(SpawnCoroutine());
    }
}