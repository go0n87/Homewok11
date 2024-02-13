using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateBonus : MonoBehaviour
{
    public int BonusCount = 0;
    public Text BonusValue;
    public void RefreshBonus()
    {
        BonusCount = ++BonusCount;
        BonusValue.text = BonusCount.ToString();
    }

}
