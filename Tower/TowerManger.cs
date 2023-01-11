using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class TowerManger : MonoBehaviour
{
    [Header("Tower tiles and panel")]
    public Tilemap towerTiles;
    public Image towerBuildPanel;

    [Header("Tower Prefab and releated buttons")]
    public Image meleeTowerButton;
    public Image rangeTowerButton;
    public GameObject meleeTower;
    public GameObject rangeTower;

    [Header("Troops Prefab")]
    public GameObject melleeTroops;

    private int mouseClickCounter;
    private Vector3Int towerLocation;

    private void Start()
    {
        meleeTowerButton.GetComponent<Button>().onClick.AddListener(BuildMeleeTower);
        rangeTowerButton.GetComponent<Button>().onClick.AddListener(BuildRangeTower);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = towerTiles.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            
            if (towerTiles.GetTile(mousePos))
            {
                towerLocation = mousePos;
                var towerScreenLocation = Camera.main.WorldToScreenPoint(towerTiles.CellToWorld(towerLocation));
                var xOffSet = 38;
                var yOffSet = 35;
                towerBuildPanel.gameObject.transform.position = new Vector3((float)(towerScreenLocation.x + xOffSet), (float)(towerScreenLocation.y + yOffSet), towerScreenLocation.z);
                towerBuildPanel.gameObject.SetActive(true);
            }

            mouseClickCounter++;
            if(!towerTiles.GetTile(mousePos) && !EventSystem.current.IsPointerOverGameObject() && mouseClickCounter > 1)
            {
                towerBuildPanel.gameObject.SetActive(false);
                mouseClickCounter = 0;
            }
        }
    }

    private void BuildMeleeTower()
    {
        var xOffSet = 0.45;
        var yOffSet = 1.2;
        Instantiate(meleeTower, new Vector3((float)(towerLocation.x + xOffSet), (float)(towerLocation.y + yOffSet), towerLocation.z), Quaternion.identity);
        towerBuildPanel.gameObject.SetActive(false);
    }

    private void BuildRangeTower()
    {
        var xOffSet = 0.45;
        var yOffSet = 1.4;
        Instantiate(rangeTower, new Vector3((float)(towerLocation.x + xOffSet), (float)(towerLocation.y + yOffSet), towerLocation.z), Quaternion.identity);
        towerBuildPanel.gameObject.SetActive(false);
    }
}
