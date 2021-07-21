using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsMoveUp : MonoBehaviour
{
    Vector3 move;
    public float speed;
    public float endPointY;
    public float startPointY;
    public float rangePointX;
    private void Awake() {
        move.y=speed;
    }
    private void OnEnable() 
    {
        transform.position=new Vector3(Random.Range(-rangePointX,rangePointX),startPointY,0);
        if(this.CompareTag("Spiked Ball")) transform.GetChild(1).transform.localPosition=new Vector3(2.5f,-1f,0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position+=move*Time.fixedDeltaTime;
        if(transform.position.y>endPointY)
        {
            Spawner.instance.ReturnPool(gameObject);
        }   
    }
}
