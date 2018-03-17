﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Wavespawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public Text waveCountDownText;


    private int waveIndex = 0;

    void Update()
    {
        
        if (countdown <= 0f)
        {
            if (waveIndex > 3)
            {
                timeBetweenWaves = timeBetweenWaves = 30;
            }
            StartCoroutine(Spawnwave());
            countdown = timeBetweenWaves;
        }
        
        countdown -= Time.deltaTime;
        waveCountDownText.text = Mathf.Round(countdown).ToString();

    }

    IEnumerator Spawnwave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {

            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        


    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }

}

