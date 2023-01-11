using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    [Header("Enemies Prefab")]
    public GameObject goblinTorch;
    [Header("Enemies WayPoint")]
    public Transform[] wayPoint1;
    public Transform[] wayPoint2;

    private Dictionary<GameObject, int> enemiesWave1= new Dictionary<GameObject, int>();
    private List<GameObject> currentEnemies = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        enemiesWave1.Add(goblinTorch,6);
        foreach (var enemies in enemiesWave1)
        {
            for (var i = 0; i < enemies.Value; i++)
            {
                var xOffSet = 1.4;
                var enemy = Instantiate(enemies.Key, new Vector3((float)(wayPoint1[0].position.x + i * xOffSet), 
                    wayPoint1[0].position.y, 0), Quaternion.identity);
                enemy.AddComponent<Enemy>();
                currentEnemies.Add(enemy);
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (var enemy in currentEnemies)
        {
            var enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.AnimationIsWalking();

            if (enemy.transform.position != wayPoint1[1].position && !enemyScript.point1ToPoint2)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, wayPoint1[1].position,
                    enemyScript.enemyMovingSpeed * Time.deltaTime);
                if (enemy.transform.position == wayPoint1[1].position) { enemyScript.point1ToPoint2 = true; } 
            }

            if(enemy.transform.position != wayPoint1[2].position && enemyScript.point1ToPoint2 && !enemyScript.point2ToPoint3)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, wayPoint1[2].position,
                    enemyScript.enemyMovingSpeed * Time.deltaTime);
                if (enemy.transform.position == wayPoint1[2].position) { enemyScript.point2ToPoint3 = true; }
            }

            if (enemy.transform.position != wayPoint1[3].position && enemyScript.point1ToPoint2 && enemyScript.point2ToPoint3 && !enemyScript.point3ToPoint4)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, wayPoint1[3].position,
                    enemyScript.enemyMovingSpeed * Time.deltaTime);
                if (enemy.transform.position == wayPoint1[3].position) { enemyScript.point3ToPoint4 = true; }
            }
        }
    }
}
