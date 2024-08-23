using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set;}
    [SerializeField] int loadingTime;
    private SceneController sc;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

        if(Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

        
        Player = GameObject.FindGameObjectWithTag("Player");
        sc = gameObject.GetComponent<SceneController>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        sc.switchScene(sceneName, loadingTime);
    }
}
