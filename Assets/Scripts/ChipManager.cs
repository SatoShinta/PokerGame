using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChipManager : MonoBehaviour
{
    [SerializeField, Header("�v���C���[�̃`�b�v")] public int _maxPlayerChip;
    [SerializeField, Header("�G�̃`�b�v")] public int _maxEnemyChip;
    public int pTotalAmount;
    public int eTotalAmount;
    [SerializeField] GameObject _Player;
    [SerializeField] GameObject _Enemy;
    [SerializeField] Animator _Animator;
    [SerializeField] Animator _Animator2;

    [SerializeField] Slider pSlider;
    [SerializeField] Slider eSlider;
    [SerializeField] InputField pInputField;
    [SerializeField] Text PlayerChipText;
    [SerializeField] Text PlayerRestChipText;
    [SerializeField] Text CoutionText;
    [SerializeField] Text EnemyChipText;
    [SerializeField] Text EnemyRestChipText;
    public bool _betChips;
    public bool _gameStart;

    public void Start()
    {
        //pSlider = GetComponent<Slider>();
        //pInputField = GetComponent<InputField>();
        _maxPlayerChip = 500;
        _maxEnemyChip = 500;
        PlayerRestChipText.text = "�c��`�b�v\n" + _maxPlayerChip;
        EnemyRestChipText.text = _maxEnemyChip + "\n�c��`�b�v"; 
        _betChips = false;
    }

    public void Update()
    {
        //PlayerChipText.text = "�q�����`�b�v\n" + pTotalAmount.ToString();
        //PlayerRestChipText.text = "�c��`�b�v\n" + _maxPlayerChip;
        //EnemyChipText.text = "�q�����`�b�v\n" + eTotalAmount.ToString();
        //EnemyRestChipText.text = _maxEnemyChip + "\n�c��`�b�v";
    }

    public void PlayerChipsDecision()
    {
        
        int betAmount;
        if (int.TryParse(pInputField.text, out betAmount) && betAmount >= 0 && betAmount <= _maxPlayerChip)
        {
            pTotalAmount += betAmount;
            _maxPlayerChip -= betAmount;
            DOTween.To(() => PlayerChipText.text, x => PlayerChipText.text = x, "�q�����`�b�v\n" + pTotalAmount.ToString(), 2f);
            // PlayerChipText.text = "�q�����`�b�v\n" +  pTotalAmount.ToString();
            PUpdateUI();
            _Animator.Play("PBetTextDown");
            EnemyChipsDecision();
        }
        else
        {
           CoutionText.text = "�|�������I�[�o�[���Ă��܂�";
            _Animator2.Play("CoutionTextUp");
        }

    }

    public void EnemyChipsDecision()
    {
        int betAmount;
        if (_betChips == true)
        {
            if(_maxEnemyChip <= 100)
            {
                betAmount = _maxEnemyChip;
                eTotalAmount += betAmount;
                _maxEnemyChip -= betAmount;
                DOTween.To(() => EnemyChipText.text, x => EnemyChipText.text = x, "�q�����`�b�v\n" + eTotalAmount.ToString(), 2f);
                EUpdateUI();
            }
            else
            {
                betAmount = Random.Range(100,_maxEnemyChip + 1);
            }

            eTotalAmount += betAmount;
            _maxEnemyChip -= betAmount;
            DOTween.To(() => EnemyChipText.text, x => EnemyChipText.text = x, "�q�����`�b�v\n" + eTotalAmount.ToString(), 2f);
            //EnemyChipText.text = "�q�����`�b�v\n" + eTotalAmount.ToString();
            EUpdateUI();
            _betChips = false;
        }
        else
        {
            Debug.Log("bbb");
        }
    }

    public void PUpdateUI()
    {
        pSlider.value = _maxPlayerChip;
        pInputField.text = string.Empty;
        DOTween.To(() => PlayerChipText.text, x => PlayerChipText.text = x, "�q�����`�b�v\n" + pTotalAmount.ToString(), 2f);

    }

    public void EUpdateUI()
    {
        eSlider.value = _maxEnemyChip;
        DOTween.To(() => EnemyChipText.text, x => EnemyChipText.text = x, "�q�����`�b�v\n" + eTotalAmount.ToString(), 2f);

    }


    public bool ConpareChip()
    {
        return _maxPlayerChip > _maxEnemyChip;
    }
}
