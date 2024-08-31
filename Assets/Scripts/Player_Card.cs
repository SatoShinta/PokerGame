using System.Collections;
using UnityEngine;

public class Player_Card : MonoBehaviour
{
    [SerializeField, Header("�J�[�h�̈ʒu")] private GameObject[] _playerCardPos;
    [SerializeField] private GameObject _playerCard;
    [SerializeField, Header("�J�[�h�̊G��")] private Sprite[] _playerCardSprite;
    [SerializeField,Header("�J�[�h�̔����Ԋu")] private float _spawnInterval = 0.5f;

    SpriteRenderer spriteRenderer;


    IEnumerator SpawnCoroutine()
    {

        //_playerCardPos�Ɋi�[����Ă���I�u�W�F�N�g�����邾�����s����
        foreach (var pos in _playerCardPos)
        {
            //_spawnInterval�̎��ԕ��������s��҂�
            yield return new WaitForSeconds(_spawnInterval);

            //��D�ɗ���G���������_���ɂ���
            int randomIndex = Random.Range(0, _playerCardSprite.Length);
            spriteRenderer.sprite = _playerCardSprite[randomIndex];

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