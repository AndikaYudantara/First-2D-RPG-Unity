using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUI : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    string textDamage;

    public void setLevel(int lvl)
    {
        textDamage = lvl.ToString()+'.';
        textUI.text = textDamage;
    }
}
