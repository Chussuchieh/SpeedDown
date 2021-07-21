using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMoveUp : MonoBehaviour
{
    Material backGround;
    float offSetY; 
    public float moveSpeed;
    private void Awake() 
    {
        backGround=GetComponent<Renderer>().material;    
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        offSetY-=moveSpeed*Time.fixedDeltaTime;;
        backGround.mainTextureOffset=new Vector2(0,offSetY);
    }
}
