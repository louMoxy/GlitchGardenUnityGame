using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    void Start()
    {
        starText = GetComponent<Text>();
        updateDisplay();
    }

    public void addStars(int starsToAdd)
    {
        stars += starsToAdd;
        updateDisplay();
    }

    public void removeStars(int starsToRemove)
    {
        if(stars >= starsToRemove)
        {
            stars -= starsToRemove;
            updateDisplay();
        }
    }

    public bool haveEnoughStars(int amount)
    {
        return amount <= stars;
    }

    private void updateDisplay()
    {
        starText.text = stars.ToString();
    }
}
