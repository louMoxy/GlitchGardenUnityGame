using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] float health = 5;
    [SerializeField] int damage = 1;
    Text healthText;

    void Start()
    {
        health = health * PlayerPrefsController.GetDifficulty();
        Debug.Log(PlayerPrefsController.GetDifficulty());
        healthText = GetComponent<Text>();
        updateDisplay();
    }

    public void takeLife()
    {
        health -= damage;
        updateDisplay();
        if(health <= 0)
        {
            FindObjectOfType<LevelController>().LoseLevel();
        }
    }

    private void updateDisplay()
    {
        healthText.text = health.ToString();
    }
}

