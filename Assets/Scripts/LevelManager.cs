using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Level[] levels;
    public int currentLevel; //mevcut level.
    private PlayerController _player;
    private Vector3 playerDefaultPosition;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerDefaultPosition = _player.transform.position;
    }
    public void StartLevel()
    {

        levels[currentLevel% levels.Length].gameObject.SetActive(true);//dizi içerisine mevcut leveli alýp, gameobjecti o levelin aktif etmesi gerekli.
        //levels[currentLevel % levels.Length].StartLevel();
        _player.transform.position = playerDefaultPosition;


    }
    public void StartNextLevel()
    {
        levels[currentLevel % levels.Length].ResetLevel();

        levels[currentLevel % levels.Length].gameObject.SetActive(false); //bir önceki leveli deaktif et.
        currentLevel++;
        StartLevel();
    }
    public void EndLevel()
    {

    }
    //private void Update()
    //{

    //}
}

