using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] InputField eInputField;
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
        PlayerChipText.text = "�q�����`�b�v\n" + pTotalAmount.ToString();
        PlayerRestChipText.text = "�c��`�b�v\n" + _maxPlayerChip;
        EnemyChipText.text = "�q�����`�b�v\n" + eTotalAmount.ToString();
        EnemyRestChipText.text = _maxEnemyChip + "\n�c��`�b�v";
    }

    public void PlayerChipsDecision()
    {
        
        int betAmount;
        if (int.TryParse(pInputField.text, out betAmount) && betAmount >= 0 && betAmount <= _maxPlayerChip)
        {
            pTotalAmount += betAmount;
            _maxPlayerChip -= betAmount;
            PlayerChipText.text = "�q�����`�b�v\n" +  pTotalAmount.ToString();
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
            betAmount = Random.Range(10, _maxEnemyChip +1);
            eTotalAmount += betAmount;
            _maxEnemyChip -= betAmount;
            EnemyChipText.text = "�q�����`�b�v\n" + eTotalAmount.ToString();
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
    }

    public void EUpdateUI()
    {
        eSlider.value = _maxEnemyChip;
        eInputField.text = string.Empty;
    }
   

    public bool ConpareChip()
    {
        return _maxPlayerChip > _maxEnemyChip;
    }
}
