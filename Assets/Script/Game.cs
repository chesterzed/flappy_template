using System;
using TMPro.EditorUtilities;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private EndMenu _endMenu;

    private void OnEnable()
    {
        _startMenu.PlayButtonClick += OnPlayButtonClick;
        _endMenu.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startMenu.PlayButtonClick -= OnPlayButtonClick;
        _endMenu.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startMenu.Open();
    }

    private void OnPlayButtonClick()
    {
        _startMenu.Close();
        StartGame();
    }
    
    private void OnRestartButtonClick()
    {
        _endMenu.Close();
        _pipeGenerator.ResetAll();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _endMenu.Open();
    }
}
