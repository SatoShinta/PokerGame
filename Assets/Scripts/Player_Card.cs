using System.Collections;
using UnityEngine;

public class Player_Card : MonoBehaviour
{
    [SerializeField, Header("カードの位置")] private GameObject[] _playerCardPos;
    [SerializeField] private GameObject _playerCard;

    [SerializeField] private float _spawnInterval = 0.5f;
    // int _spawnCount = 3;

    IEnumerator SpawnCoroutine()
    {
        foreach (var pos in _playerCardPos)
        {
            yield return new WaitForSeconds(_spawnInterval);
            Instantiate(_playerCard, pos.transform.position, Quaternion.identity);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }
}