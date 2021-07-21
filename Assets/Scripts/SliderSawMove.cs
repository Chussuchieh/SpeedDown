using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SliderSawMove : MonoBehaviour
{   
    private void OnEnable() 
    {
        StartCoroutine(SawMove(3.5f,1.5f));
    }
    IEnumerator SawMove(float endValue,float duration)
    {
        transform.DOLocalMoveX(endValue,duration);
        yield return new WaitForSeconds(duration);
        StartCoroutine(SawMove(-endValue,3f));
    }
}
