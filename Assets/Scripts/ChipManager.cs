using UnityEngine;
using UnityEngine.UI;

public class ChipManager : MonoBehaviour
{
    [SerializeField, Header("プレイヤーのチップ")] int _maxPlayerChip;
    [SerializeField, Header("敵のチップ")] int _maxEnemyChip;
    int pTotalAmount;
    int eTotalAmount;
    [SerializeField] GameObject _Player;
    [SerializeField] GameObject _Enemy;

    [SerializeField] Slider pSlider;
    [SerializeField] Slider eSlider;
    [SerializeField] InputField pInputField;
    [SerializeField] InputField eInputField;
    [SerializeField] Text PlayerChipText;
    [SerializeField] Text EnemyChipText;
    public bool _betChips;
    public bool _gameStart;

    public void Start()
    {
        //pSlider = GetComponent<Slider>();
        //pInputField = GetComponent<InputField>();
        _maxPlayerChip = 500;
        _maxEnemyChip = 500;
        _betChips = true;
    }

    public void Update()
    {
        
    }

    public void PlayerChipsDecision()
    {
        
        int betAmount;
        if (int.TryParse(pInputField.text, out betAmount) && betAmount >= 0)
        {
            pTotalAmount += betAmount;
            _maxPlayerChip -= betAmount;
            PlayerChipText.text = "賭けたチップ\n" +  pTotalAmount.ToString();
            PUpdateUI();
        }
        else
        {
            Debug.Log("aaa");
        }

    }

    public void EnemyChipsDecision()
    {
        int betAmount;
        if (int.TryParse(eInputField.text, out betAmount) && betAmount >= 0)
        {
            eTotalAmount += betAmount;
            _maxEnemyChip -= betAmount;
            EnemyChipText.text = "賭けたチップ\n" + eTotalAmount.ToString();
            EUpdateUI();
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
}
