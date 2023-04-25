using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
/*
 * Data  is provided from ORNL DAAC, Distributed Active Archive Center for Biogeochemical Dynamics.

Jacobs, N., W.R. Simpson, F. Hase, T. Blumenstock, Q. Tu, M. Frey, M.K. Dubey, and H.A. Parker. 2021. Ground-based Observations of XCO2,
XCH4, and XCO, Fairbanks, AK, 2016-2019. ORNL DAAC, Oak Ridge, Tennessee, USA. https://doi.org/10.3334/ORNLDAAC/1831

Diego Velasco, 11 April 2023
 */

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = UnityEngine.Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(
            UnityEngine.Random.Range(
                -spawnRangeX, spawnRangeX),
                 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex],
            spawnPos,
            animalPrefabs[animalIndex].transform.rotation);
     }

}
