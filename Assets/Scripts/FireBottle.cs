using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBottle : MonoBehaviour
{
    Animator animator;
    private void Awake() 
    {
        animator=GetComponent<Animator>();
    }
    private void OnEnable() 
    {
        StartCoroutine(PlayFire());
    }
    IEnumerator PlayFire()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("Fire",true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Fire",false);
        StartCoroutine(PlayFire());
    }
}
