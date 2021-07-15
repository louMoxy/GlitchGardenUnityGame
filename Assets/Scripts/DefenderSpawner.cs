using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    public void setSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        if(StarDisplay.haveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.removeStars(defenderCost);
        }
    }

    private void OnMouseDown()
    {
        if (defender)
        {
            AttemptToPlaceDefenderAt(GetSquareClicked());
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 position)
    {
        Defender newDefender = Instantiate(defender, position, Quaternion.identity);
    }
}
