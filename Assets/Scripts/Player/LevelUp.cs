using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelUp : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI textUI;

    string textDamage;

    public void showLevelUp(int level)
    {
        textDamage = "Level Up !";
        textUI.text = textDamage;
        animator.SetTrigger("LevelUp");
    }
}
