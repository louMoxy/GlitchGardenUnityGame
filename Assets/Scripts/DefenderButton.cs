using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void OnMouseDown()
    {
        var allButtons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in allButtons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().setSelectedDefender(defenderPrefab);
    }
}
