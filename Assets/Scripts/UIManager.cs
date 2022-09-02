using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameManager _gameManager;
    public Button btnStart, btnNextLevel;
    public GameObject menuUI, inGameUI, endUI;
    public TextMeshProUGUI txtLevel;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        SetBindings();
    }

    private void SetBindings()
    {
        btnStart.onClick.AddListener(() =>
        {
            _gameManager.StartGame();
            menuUI.SetActive(false);
            inGameUI.SetActive(true);
        }
        );
        btnNextLevel.onClick.AddListener(() =>
        {
            endUI.SetActive(false);
            _gameManager.StartNextGame();
            inGameUI.SetActive(true);
        }

        );
       
      
    }
    public void UpdateLevelText(int level)
    {
        txtLevel.text = "LEVEL" + (level+1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndLevel()
    {
        inGameUI.SetActive(false);
        endUI.SetActive(true);
    }
}
