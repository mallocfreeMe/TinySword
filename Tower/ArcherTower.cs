using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ArcherTower : MonoBehaviour
{
    public FieldOfView fov;
    public Animator animator;
    public GameObject arrowPrefab;
    public Transform arrowShootPoint;

    private const string IsShootUp = "IsShootUp";
    private const string IsShooDiagonalUp = "IsShooDiagonalUp";
    private const string IsShootFront = "IsShootFront";
    private const string IsShootDown = "IsShootDown";
    private const string IsShootDiagonalDown = "IsShootDiagonalDown";

    //private List<GameObject> arrows = new();
    private float posX, posY;

    private void Start()
    {
        posX = fov.transform.position.x;
        posY = fov.transform.position.y;
    }

    private void Update()
    {
        if(fov.visibleTargets.Count > 0)
        {
            //arrows.Add(Instantiate(arrowPrefab,arrowShootPoint));

            //var arrowShootSpeed = 0.5f;
            /*foreach(var arrow in arrows)
            {
                arrow.transform.position = Vector3.MoveTowards(arrow.transform.position, fov.visibleTargets[0].transform.position, arrowShootSpeed * Time.deltaTime);
            } */ 

            var targetPos = fov.visibleTargets[0].position;
            var targetPosX = targetPos.x;
            var targetPosY = targetPos.y;


            // up 
            if (posX == targetPosX && posY < targetPosY)
            {
                animator.SetBool(IsShootUp, true);
                animator.SetBool(IsShooDiagonalUp, false);
                animator.SetBool(IsShootFront, false);
                animator.SetBool(IsShootDown, false);
                animator.SetBool(IsShootDiagonalDown, false);

                animator.transform.localScale = new Vector3(1, 1, 1);
            }

            // right up diagnoal
            if (posX < targetPosX && posY < targetPosY)
            {
                animator.SetBool(IsShootUp, false);
                animator.SetBool(IsShooDiagonalUp, true);
                animator.SetBool(IsShootFront, false);
                animator.SetBool(IsShootDown, false);
                animator.SetBool(IsShootDiagonalDown, false);

                animator.transform.localScale = new Vector3(1, 1, 1);
            }

            // right front
            if (posX < targetPosX && posY == targetPosY)
            {
                animator.SetBool(IsShootUp, false);
                animator.SetBool(IsShooDiagonalUp, false);
                animator.SetBool(IsShootFront, true);
                animator.SetBool(IsShootDown, false);
                animator.SetBool(IsShootDiagonalDown, false);

                animator.transform.localScale = new Vector3(1, 1, 1);
            }

            // right bottom diagnoal
            if (posX < targetPosX && posY > targetPosY)
            {
                animator.SetBool(IsShootUp, false);
                animator.SetBool(IsShooDiagonalUp, false);
                animator.SetBool(IsShootFront, false);
                animator.SetBool(IsShootDown, false);
                animator.SetBool(IsShootDiagonalDown, true);

                animator.transform.localScale = new Vector3(1, 1, 1);
            }

            // right bottom
            if (posX == targetPosX && posY < targetPosY)
            {
                animator.SetBool(IsShootUp, false);
                animator.SetBool(IsShooDiagonalUp, false);
                animator.SetBool(IsShootFront, false);
                animator.SetBool(IsShootDown, true);
                animator.SetBool(IsShootDiagonalDown, false);

                animator.transform.localScale = new Vector3(1, 1, 1);
            }

            // left bottom diagnoal
            if (posX > targetPosX && posY > targetPosY)
            {
                animator.SetBool(IsShootUp, false);
                animator.SetBool(IsShooDiagonalUp, false);
                animator.SetBool(IsShootFront, false);
                animator.SetBool(IsShootDown, false);
                animator.SetBool(IsShootDiagonalDown, true);

                animator.transform.localScale = new Vector3(-1,1,1);
            }

            //left front
            if (posX > targetPosX && posY == targetPosY)
            {
                animator.SetBool(IsShootUp, false);
                animator.SetBool(IsShooDiagonalUp, false);
                animator.SetBool(IsShootFront, true);
                animator.SetBool(IsShootDown, false);
                animator.SetBool(IsShootDiagonalDown, false);

                animator.transform.localScale = new Vector3(-1, 1, 1);
            }

            //left up diagnoal
            if (posX < targetPosX && posY < targetPosY)
            {
                animator.SetBool(IsShootUp, false);
                animator.SetBool(IsShooDiagonalUp, true);
                animator.SetBool(IsShootFront, false);
                animator.SetBool(IsShootDown, false);
                animator.SetBool(IsShootDiagonalDown, false);

                animator.transform.localScale = new Vector3(-1, 1, 1);
            }

        } else
        {
            animator.SetBool(IsShootUp, false);
            animator.SetBool(IsShooDiagonalUp, false);
            animator.SetBool(IsShootFront, false);
            animator.SetBool(IsShootDown, false);
            animator.SetBool(IsShootDiagonalDown, false);
        }
    }
}
