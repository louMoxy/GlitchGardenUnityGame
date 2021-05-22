using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = EditorSceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
            LoadNextScene();
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
    }

    public void LoadNextScene()
    {
        EditorSceneManager.LoadScene(++currentSceneIndex);
    }
}
