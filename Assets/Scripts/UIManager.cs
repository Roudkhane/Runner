using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private Text txtScore;
    [SerializeField] private Text txtFuel;
    [SerializeField] private int Score;
    [SerializeField] private int Fuel;
    [SerializeField] private float time;
    [SerializeField] private GameObject bgGameOver;
    [SerializeField] private bool gameover = true;
    private void Awake() => Instance = this;
    
    private void Start()
    {
        Score = 0;
        txtScore.text = Score.ToString();
        Fuel = 100;
        txtFuel.text = Fuel.ToString();
        time = 0;
    }

    private void Update()
    {
        if (gameover)
        {

            if (time < 4)
            {
                time += Time.deltaTime;
            }
            else if (time > 4)
            {
                decreaseFuel(2);
                time = 0;
            }
        }
    }


    public void AddScore(int value)
    {
        Score += value;
        txtScore.text = Score.ToString();
    }


    public void AddFuel(int value)
    {
        Fuel += value;
        txtFuel.text = Fuel.ToString();
    }

    public void decreaseFuel(int value)
    {
        if (Fuel < 0)
        {
            GameOver();
        }
        Fuel -= value;
        txtFuel.text = Fuel.ToString();
    }

    public void GameOver()
    {
        bgGameOver.SetActive(true);
        gameover = false;
        TirController.isclick = false;

    }
}
