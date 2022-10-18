using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _score = 0;

    private void Start()
    {
        SetScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ScoreBlock scoreBlock))
        {
            _score += scoreBlock.scoreValue;
            SetScoreText();
            DestroyBlockAfterScoring(other.gameObject);
        }
    }

    private void DestroyBlockAfterScoring(GameObject block)
    {
        Destroy(block.gameObject);
    }
    
    private void SetScoreText()
    {
        _scoreText.SetText(_score.ToString());
    }
}