using UnityEngine;
using UnityEngine.InputSystem;

public class WorldGenerator2 : MonoBehaviour
{
    public float radius;
    public float spawnChance;
    
    private Vector3 perlinOffset;
    public float perlinFloat;

    public float perlinScale;
    public float perlinScale2;
    
    public float scale;
    public float AsteroidSize = 1;
    public GameObject Asteroid;
    public GameObject Asteroid1;
    public GameObject Asteroid2;
    public GameObject Asteroid3;
    public GameObject Asteroid4;

    public GameObject AsteroidFolder;

    private float middleOfTheWorld;
    private bool findingNewSpot;

    public GameObject PlayerSpawnPoint;
    public bool newSpotAvaliable;
    public float ShipRadius;
    private Object cameraPrefab;

    public PlayerInputManager playerInputManager;

    public int spawnPoints;

    private int PlayerNo = 0;
    private void Start()
    {
        perlinOffset.x = Random.Range(-99999, 99999);
        perlinOffset.y = Random.Range(-99999, 99999);
        
        GenerateLevel();
    }

    public float CalculatePerlin(float x, float y)
    {
        float xCoord = x * scale + perlinOffset.x;
        float yCoord = y * scale + perlinOffset.y;
        perlinFloat = Mathf.PerlinNoise(xCoord * perlinScale, yCoord* perlinScale)* perlinScale2;
        return perlinFloat;
    }

    public void GenerateLevel()
    {
        for (int x = 0; x < (radius*2); x++)
        {
            for (int y = 0; y < radius*2; y++)
            {

                if (CheckSpawn(x*AsteroidSize, y*AsteroidSize))
                {
                    var newSpawnLoc = new Vector3(x*AsteroidSize, y*AsteroidSize, 0);
                    CalculatePerlin(newSpawnLoc.x, newSpawnLoc.y);
                    if (perlinFloat <= spawnChance)
                    {
                        SpawnAsteroid(newSpawnLoc);
                    }
                }
            }
        }
        FindNewPlayer();
    }

    public bool CheckSpawn(float x, float y)
    {
        float distance = Mathf.Sqrt(Mathf.Pow((radius - x), 2) + Mathf.Pow((radius - y), 2));
        if (distance <= radius)
        {
            return true;
        }

        return false;
    }

    void SpawnAsteroid(Vector3 Postion)
    {
        var newChance = Random.Range(1, 100);
        if (newChance <= 55)
        {
            Instantiate(Asteroid, Postion, Quaternion.identity, AsteroidFolder.transform);
        }
        if (newChance <= 80 && newChance > 55)
        {
            Instantiate(Asteroid1, Postion, Quaternion.identity, AsteroidFolder.transform);
        }
        if (newChance <= 90 && newChance > 80)
        {
            Instantiate(Asteroid2, Postion, Quaternion.identity, AsteroidFolder.transform);
        }
        if (newChance <= 98 && newChance > 90)
        {
            Instantiate(Asteroid3, Postion, Quaternion.identity, AsteroidFolder.transform);
        }
        if (newChance <= 100 && newChance > 98)
        {
            Instantiate(Asteroid4, Postion, Quaternion.identity, AsteroidFolder.transform);
        }
    }

    public void FindNewPlayer()
    {
        findingNewSpot = true;
    }

    private void Update()
    {
        if (findingNewSpot)
        {
            var x = Random.Range(0, radius*2);
            var y = Random.Range(0, radius*2);
            if (CheckSpawn(x, y))
            {
                PlayerSpawnPoint.transform.position = new Vector3(x, y, 0);
                newSpotAvaliable = true;
                findingNewSpot = false;
            }
        }
    }

    public void PlaceNewPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(PlayerSpawnPoint.transform.position, ShipRadius, int.MaxValue, QueryTriggerInteraction.Collide);
        foreach (var variable in hitColliders)
        {
            variable.GetComponent<RockController>()?.DestroyGameObject();
        }
        if (newSpotAvaliable)
        {
            FindNewPlayer();
        }
    }
    
    public void Awake()
    {
        if (playerInputManager != null) playerInputManager.onPlayerJoined += PlayerInputManagerOnonPlayerJoined;
    }

    private void PlayerInputManagerOnonPlayerJoined(PlayerInput aObj)
    {
        aObj.transform.GetComponent<PlayerController>().ParentTransform.position = new Vector3(PlayerSpawnPoint.transform.position.x, PlayerSpawnPoint.transform.position.y, 0);
        aObj.transform.GetComponent<PlayerController>().PlayerIndex = PlayerNo;
        PlayerNo++;
        PlaceNewPlayer();
    }
}
