using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public GameObject buttonCanvas;
    public float timeToRestart;
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void StartGame()
    {
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(timeToRestart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
