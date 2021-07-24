using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    [SerializeField] float winLoadingTime = 4;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(levelTimerFinished && numberOfAttackers <= 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();

    }

    public void LoseLevel()
    {
        loseLabel.SetActive(true);
        winLabel.SetActive(false);
        Time.timeScale = 0;
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(winLoadingTime);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
}
