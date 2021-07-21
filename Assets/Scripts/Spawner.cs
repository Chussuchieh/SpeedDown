using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public float startPoint;
    public List<GameObject> spawners = new List<GameObject>();
    public float spawnTime;
    private float spawnTimeCounter;
    private void Awake() {
        instance = this;
    }
    private void Start() 
    {
        for(int i=0;i<transform.childCount;i++)
        {
            spawners.Add(transform.GetChild(i).gameObject);
        }
    }
    private void FixedUpdate() 
    {
        spawnTimeCounter-=Time.fixedDeltaTime;
        if(spawnTimeCounter<0) InstantiateNew();
    }
    public void ReturnPool(GameObject spawner)
    {
        spawner.SetActive(false);
        spawner.transform.position=new Vector3(0,startPoint,0);
        spawners.Add(spawner);
    }
    void InstantiateNew()
    {
        int index=Random.Range(0,spawners.Count);
        spawners[index].SetActive(true);
        spawners.RemoveAt(index);
        spawnTimeCounter=spawnTime;
    }
}
