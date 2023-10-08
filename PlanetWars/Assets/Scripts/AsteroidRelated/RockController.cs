using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public Destroyable destroyable;
    public GameObject crystal;
    private Vector3 spawnPos;
    private Quaternion spawnRot;
    
    public void Start()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,0f);
    }

    private void Update()
    {
        if (destroyable.health <= 0)
        {
            AsteriodDestroy();
            
        }
    }

    public void AsteriodDestroy()
    {

        if (crystal != null)
        {
            int noOfCrystals = Random.Range(1, 5);
            for (int i = 0; i < noOfCrystals; i++)
            {
                spawnPos = new Vector3(transform.position.x + Random.Range(-2,3), transform.position.y + Random.Range(-2,3), 0f);
                spawnRot = new Quaternion(Random.Range(-180f, 180f), 0f, 0f, 0f);
                Instantiate(crystal, spawnPos, spawnRot);
            }
        }
        
        Destroy(gameObject);
    }
}
