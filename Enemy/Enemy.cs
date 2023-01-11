using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool point1ToPoint2;
    public bool point2ToPoint3;
    public bool point3ToPoint4;

    public float enemyMovingSpeed = 0.8f;

    public void AnimationIsWalking()
    {
        this.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
    }
}
