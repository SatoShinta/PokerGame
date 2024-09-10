using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipManager : MonoBehaviour
{
    [SerializeField, Header("プレイヤーのチップ")] int _PlayerChip = 500;
    [SerializeField, Header("敵のチップ")] int _EnemyChip = 500;
    [SerializeField] GameObject _Player;
    [SerializeField] GameObject _Enemy;
    Slider Slider;
    InputField InputField;

    public void Start()
    {
        Slider = GetComponent<Slider>();
        InputField = GetComponent<InputField>();
    }

    public void Update()
    {
        
    }


}
