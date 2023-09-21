using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpownMonster : MonoBehaviour
{
    public GameObject[] EnemyPf;
    public float SpawnInterval;
    public float SpawnDistance;

    public GameObject SpawnPlace;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnMonster()
    {
        while (true)
        {
            
            var rand = Random.insideUnitCircle*SpawnDistance;

            var SpawnPos = SpawnPlace.transform.position;

            SpawnPos.x += rand.x;
            SpawnPos.z += rand.y;

            Enemy enemy = Instantiate(EnemyPf[0], SpawnPos, Quaternion.identity).GetComponent<Enemy>();




            yield return new WaitForSeconds(SpawnInterval);
        }
       
    }
}
