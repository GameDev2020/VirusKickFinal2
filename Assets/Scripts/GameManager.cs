using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; set; }

    [SerializeField]
    public float gameSpeedMin = 0;
    [SerializeField]
    public float gameSpeedMax = 0;
    [SerializeField]
    public GameObject ExplosionVFX;
    private float time = 0;
    public string scene;
    public float nextLeveltime;

    private GameObject Player;

    public float CurrentGameSpeed { get; set; }
   

    public bool startGame { get; set; }

    public delegate void OnGameStart();
    public static event OnGameStart onGameStart;
    public static event OnGameStart onGameEnd;

    public int Score { get; set; }
    public int HighScore{ get; set; }

    float timer = 0.0f;
    int seconds;


    private void Awake()
    {
        Instance = this;
        CurrentGameSpeed = 0;        
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        startGame = false;
        ShipCollsion.onCollision += ResetLevel;
        StartCoroutine(WaitForSpace());
    }


    IEnumerator WaitForSpace()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        GameStart();
    }

    private void GameStart()
    {
        onGameStart();
        CurrentGameSpeed = gameSpeedMin;
        startGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            timer += Time.deltaTime * CurrentGameSpeed;
            Score = Convert.ToInt32(timer);

            if(CurrentGameSpeed< gameSpeedMax)
                CurrentGameSpeed += Time.deltaTime / 500;

            Debug.Log(CurrentGameSpeed);
            time += Time.deltaTime;
            if (GameManager.Instance.CurrentGameSpeed != 0)
            {
                if (time > nextLeveltime / GameManager.Instance.CurrentGameSpeed)
                {
                    ResetLevel();
                    SceneManager.LoadScene(scene);

                }
            }
        }
   
    }
    

    public void ResetLevel()
    {
        //onGameEnd();
        time = 0;
        CurrentGameSpeed = 0;
        startGame = false;
        timer = 0;
        StartCoroutine(WaitForSpace());
    }
}
