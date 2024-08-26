using System.Collections;
using UnityEngine;

public class Player_Card : MonoBehaviour
{
    [SerializeField, Header("�J�[�h�̈ʒu")] private GameObject[] _playerCardPos;
    [SerializeField] private GameObject _playerCard;

    [SerializeField,Header("�J�[�h�̔����Ԋu")] private float _spawnInterval = 0.5f;
    

    IEnumerator SpawnCoroutine()
    {
        //_playerCardPos�Ɋi�[����Ă���I�u�W�F�N�g�����邾�����s����
        foreach (var pos in _playerCardPos)
        {
            //_spawnInterval�̎��ԕ��������s��҂�
            yield return new WaitForSeconds(_spawnInterval);
            //_playerCard�Ɋi�[����Ă���J�[�h��_playerCardPos�̏ꏊ�ɐ�������
            Instantiate(_playerCard, pos.transform.position, Quaternion.identity);
        }
    }

    private void Start()
    {
        //�Q�[���J�n���Ɏ��s
        StartCoroutine(SpawnCoroutine());
    }
}