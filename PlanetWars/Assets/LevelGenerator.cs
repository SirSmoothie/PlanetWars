using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float maxGenDistance;
    public float maxPlayerGenDistance;
    public int numberOfPlanets;
    public int numberOfPlayers;
    public GameObject Sun;
    public GameObject Moon;
    public GameObject Planet;
    public GameObject PlayerCharacter;
    public float x;
    public float y;
    public Vector3 genTarget;
    public GameObject PlanetBodyParents;
    public GameObject PlayerBodyParents;
    public GameObject TurnTrackerObject, MouseObject;
    private void Start()
    {
        for (int i = 0; i < numberOfPlanets; i++)
        {
            x = Random.Range(-maxGenDistance, maxGenDistance);
            y = Random.Range(-maxGenDistance, maxGenDistance);
            genTarget = new Vector3(x, y, 0);
            int planetIndex = Random.Range(1, 4);
            switch (planetIndex)
            {
                case 1:
                    Instantiate(Sun,genTarget, Quaternion.identity, PlanetBodyParents.transform);
                    break;
                case 2:
                    Instantiate(Moon,genTarget, Quaternion.identity, PlanetBodyParents.transform);
                    break;
                case 3:
                    Instantiate(Planet,genTarget, Quaternion.identity, PlanetBodyParents.transform);
                    break;
            }
        }

        for (int i = 0; i < numberOfPlayers; i++)
        {
            x = Random.Range(-maxPlayerGenDistance, maxPlayerGenDistance);
            y = Random.Range(-maxPlayerGenDistance, maxPlayerGenDistance);
            genTarget = new Vector3(x, y, 0);
            GameObject InstancitedAsset;
            InstancitedAsset = Instantiate(PlayerCharacter, genTarget, Quaternion.identity, PlayerBodyParents.transform);
            InstancitedAsset.GetComponent<PlayerActivator>().turnTracker = TurnTrackerObject;
            InstancitedAsset.GetComponent<PlayerActivator>().controller.GetComponent<Aiming>().Mouse = MouseObject;
            InstancitedAsset.GetComponent<PlayerActivator>().controller.GetComponent<Aiming>().turnTracker = TurnTrackerObject;
        }
    }
}
