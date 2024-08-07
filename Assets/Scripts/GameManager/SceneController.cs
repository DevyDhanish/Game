using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour
{
    [SerializeField] private RectTransform loadingScreen;
    [SerializeField] private Transform houseSpawnPoint;

    void Start()
    {
        loadingScreen.gameObject.SetActive(false);
    }

    public void switchScene(string sceneName, int loadingTime)
    {
        StartCoroutine(loadingBlackScreen(sceneName, loadingTime));
    }

    IEnumerator loadingBlackScreen(string name, int time)
    {
        loadingScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        GameController.Instance.Player.transform.position = houseSpawnPoint.position;
        loadingScreen.gameObject.SetActive(false);
    }
}
