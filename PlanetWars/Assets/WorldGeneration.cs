using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public float perlinFloat;

    public float Scale = 10f;

    public float offsetx;
    public float offsety;

    public GameObject Asteroid, Asteroid1, Asteroid2, Asteroid3, Asteroid4;

    private Vector2 asteroidPos;

    public float PosScale;
    
    public float chance;
    void Update()
    {
    }

    private void Start()
    {
        GenerateAsteroidWithRandom();
    }

    void GenerateAsteroidWithRandom()
    {

        for (int x =0; x < width; x++)
        {
            for(int y=0; y < height; y++)
            {
                CalculatePerlin(x, y);
                if (Random.Range(0, perlinFloat) >= chance)
                {
                    asteroidPos = new Vector2(x*PosScale, y*PosScale);
                    SpawnAsteroid();
                }
            }
        }
    }

    void SpawnAsteroid()
    {
        int asteroidChanceType = Random.Range(0, 105);
        int asteroidIndex;
        if (asteroidChanceType <= 50 && asteroidChanceType >= 0)
        {
            asteroidIndex = 0;
        }
        else if (asteroidChanceType <= 75 && asteroidChanceType >= 51)
        {
            asteroidIndex = 1;
        }
        else if (asteroidChanceType <= 90 && asteroidChanceType >= 76)
        {
            asteroidIndex = 2;
        }
        else if (asteroidChanceType <= 98 && asteroidChanceType >= 91)
        {
            asteroidIndex = 3;
        }
        else if (asteroidChanceType <= 99)
        {
            asteroidIndex = 4;
        }
        else
        {
            asteroidIndex = 0;
        }
        switch (asteroidIndex)
        {
            case 0 :
                Instantiate(Asteroid, asteroidPos, transform.rotation, transform);
                break;
            case 1 :
                Instantiate(Asteroid1, asteroidPos, transform.rotation, transform);
                break;
            case 2 :
                Instantiate(Asteroid2, asteroidPos, transform.rotation, transform);
                break;
            case 3 :
                Instantiate(Asteroid3, asteroidPos, transform.rotation, transform);
                break;
            case 4 :
                Instantiate(Asteroid4, asteroidPos, transform.rotation, transform);
                break;
        }
    }

    void CalculatePerlin(int x, int y)
    {
        float xCoord = (float)x/width * Scale + offsetx;
        float yCoord = (float)y/height * Scale + offsety;
        perlinFloat = Mathf.PerlinNoise(xCoord, yCoord);
        
    }
}
