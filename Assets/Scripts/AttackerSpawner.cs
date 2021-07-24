using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackers;

    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning() {
        spawn = false;
    }

    private void SpawnAttacker ()
    {
        int index = Mathf.RoundToInt(Random.Range(0f, attackers.Length - 1));
        Attacker selectedAttacker = attackers[index];
        Attacker newAttacker = Instantiate(selectedAttacker, transform.transform);
        newAttacker.transform.parent = transform;
    }
}
