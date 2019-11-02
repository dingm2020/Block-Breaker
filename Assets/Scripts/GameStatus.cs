using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {
    [Range(0.1f, 10f)] [SerializeField] private float game_speed = 1f;
    [SerializeField] private int current_score = 0, unit_score = 10;
    [SerializeField] private TextMeshProUGUI score_text;

    private void Awake() {
        
        int status_count = FindObjectsOfType<GameStatus>().Length;
        if (status_count > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score_text.text = current_score.ToString();
        //Debug.Log(current_score);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = game_speed;
        
    }

    public void AddScore() {
        current_score += (unit_score);
        //Debug.Log(current_score);
        score_text.text = current_score.ToString();
    }

    public void ResetGame() {
        //
        Destroy(gameObject);
    }
}
