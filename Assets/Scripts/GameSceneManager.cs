using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelRoutine());
    }

    IEnumerator ReloadLevelRoutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
