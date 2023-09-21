using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpownMonster : MonoBehaviour
{
    public GameObject[] EnemyPf;
    public float SpawnInterval;
    public float SpawnDistance;
    bool SpawnStart;
    public GameObject SpawnPlace;
    IEnumerator enumerator;
    // Start is called before the first frame update
    void Start()
    {
       
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
    private void OnTriggerEnter(Collider other)
    {
        if (!SpawnStart && other.gameObject.CompareTag("Player"))
        {
            enumerator = SpawnMonster();
            StartCoroutine(enumerator);
            SpawnStart = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(enumerator);
            SpawnStart=false;
        }
        
    }
}
