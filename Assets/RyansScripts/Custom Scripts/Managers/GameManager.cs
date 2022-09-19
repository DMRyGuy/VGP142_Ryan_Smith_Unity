using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;
    public int StartingLives = 3;
    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    private int _lives = 3;
    public int maxLives = 3;

    public int lives
    {
        get { return _lives; }
        set
        {
            if (_lives > value)
            {
                //Destroy(playerInstance.gameObject);
                //SpawnPlayer(currentLevel.spawnPoint);
                playerInstance.transform.position = currentLevel.spawnPoint.position;
            }

            _lives = value;
            onLifeValueChanged.Invoke(value);

            if (_lives > maxLives)
                _lives = maxLives;

            if (_lives <= 0)
                GameOver();

            Debug.Log("Lives Set To: " + lives.ToString());
        }
    }

    public Character playerPrefab;
    [HideInInspector] public Character playerInstance;
    [HideInInspector] public Level currentLevel;
    [HideInInspector] public UnityEvent<int> onLifeValueChanged;

    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        lives = StartingLives;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (SceneManager.GetActiveScene().name == "Start")
        //        SceneManager.LoadScene("Level");
        //    else if (SceneManager.GetActiveScene().name == "GameOver")
        //        SceneManager.LoadScene("Start");

        //}
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        playerInstance = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
    }
}