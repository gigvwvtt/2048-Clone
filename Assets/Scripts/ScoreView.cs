using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private GameManager _game;
    [SerializeField] private TMP_Text _scoreValueText;
    private int _score;

    private void Start()
    {
        if (_scoreValueText == null) return;
        _scoreValueText.text = _score.ToString();
    }

    private void OnEnable()
    {
        if (_game == null) return;
        _game.ScoreUpdated += OnGameUpdated;
    }

    private void OnDisable()
    {
        if (_game == null) return;
        _game.ScoreUpdated -= OnGameUpdated;
    }

    private void OnGameUpdated(int value)
    {
        _scoreValueText.text = AddToScore(value).ToString();
    }

    private int AddToScore(int value)
    {
        return _score += value;
    }
}
