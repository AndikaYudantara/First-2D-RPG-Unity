using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI textUI;

    string textDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showDamage(int damage)
    {
        textDamage = damage.ToString();
        textUI.text = textDamage;
        animator.SetTrigger("Hit");
    }
}
