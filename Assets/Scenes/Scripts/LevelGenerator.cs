﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator levelGenerator;

    public Transform mapBeginingPosition;

    [Space]
    public GameObject[] killerBalls;

    [Space]
    public GameObject hollowTerrain;
    public GameObject player;
    public GameObject terrain;
    public GameObject wall;
    public GameObject xWall;
    public GameObject vWall;
    public GameObject hWall;
    public GameObject rock;
    public GameObject box;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject door;
    public GameObject key;
    public GameObject pinkSlime;

    [Space]
    public Color levelColor;
    public float terrainSeparation;

    [HideInInspector]
    public bool playerDead = false;

    [Space]
    public string[] level =
    {
        "WWWWW",
        "WWWWW"
    };



    private void Awake()
    {
        if (levelGenerator != null)
            GameObject.Destroy(levelGenerator);
        else
            levelGenerator = this;
    }

    void Start ()
    {
        GenerateLevel();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && playerDead)
        {
            ResetPlayer();
        }
    }

    public void ResetPlayer()
    {
        for (int i = 0; i < level.Length; i++)
        {
            for (int j = 0; j < level[i].Length; j++)
            {
                if (level[i][j] == 'P')
                {
                    GameObject newPlayer = Instantiate(player, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                    newPlayer.name = "Player";
                    newPlayer.transform.parent = transform;
                }
            }
        }

        for (int i = 0; i < killerBalls.Length; i++)
        {
            killerBalls[i].GetComponent<KillerBall>().ResetBall();
        }

        playerDead = false;
    }
     
    public void GenerateLevel()
    {
        string levelHolderName = "Generated Level";

        // Condition necessary to avoid creating endless maps with the LevelEditor.cs
        if (transform.Find(levelHolderName))
            DestroyImmediate(transform.Find(levelHolderName).gameObject);

        Transform levelHolder = new GameObject(levelHolderName).transform;
        levelHolder.parent = transform;

        Transform terrainHolder = new GameObject("Terrain").transform;
        terrainHolder.parent = levelHolder;

        Transform wallHolder = new GameObject("Walls").transform;
        wallHolder.parent = levelHolder;

        Transform obstacleHolder = new GameObject("Obstacles").transform;
        obstacleHolder.parent = levelHolder;

        Transform enemyHolder = new GameObject("Enemies").transform;
        enemyHolder.parent = levelHolder;

        for (int i = 0; i < level.Length; i++)
        {
            for (int j = 0; j < level[i].Length; j++)
            {
                // Codigo super guarro necesario para pintar color
                GameObject instantion1 = null;
                GameObject instantion2 = null;

                // P - Player | T - Terrain | W- Wall |O - Obstacles
                switch (level[i][j])
                {
                    case 'P':
                        GameObject newHollowTerrain = Instantiate(hollowTerrain, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newHollowTerrain.transform.parent = terrainHolder;
                        GameObject newPlayer = Instantiate(player, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newPlayer.name = "Player";
                        newPlayer.transform.parent = levelHolder;

                        instantion1 = newHollowTerrain;
                        instantion2 = newPlayer;
                        break;
                    case 'T':
                        GameObject newTerrain = Instantiate(terrain, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newTerrain.transform.parent = terrainHolder;

                        instantion1 = newTerrain;
                        break;
                    case 'W':
                        GameObject newWall = Instantiate(wall, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newWall.transform.parent = wallHolder;

                        instantion1 = newWall;
                        break;
                    case 'V':
                        GameObject newVWall = Instantiate(vWall, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newVWall.transform.parent = wallHolder;

                        instantion1 = newVWall;
                        break;
                    case 'H':
                        GameObject newHWall = Instantiate(hWall, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newHWall.transform.parent = wallHolder;

                        instantion1 = newHWall;
                        break;
                    case 'X':
                        GameObject newXWall = Instantiate(xWall, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newXWall.transform.parent = wallHolder;

                        instantion1 = newXWall;
                        break;
                    case 'R':
                        GameObject newTerrainRock = Instantiate(terrain, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newTerrainRock.transform.parent = terrainHolder;
                        GameObject newRock = Instantiate(rock, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, -2f)), mapBeginingPosition.rotation) as GameObject;
                        newRock.transform.parent = obstacleHolder;

                        instantion1 = newTerrainRock;
                        instantion2 = newRock;
                        break;
                    case 'B':
                        GameObject newBox = Instantiate(box, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newBox.transform.parent = obstacleHolder;

                        instantion1 = newBox;
                        break;
                    case 'N':
                        GameObject newBox1 = Instantiate(box1, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newBox1.transform.parent = obstacleHolder;

                        instantion1 = newBox1;
                        break;
                    case 'M':
                        GameObject newBox2 = Instantiate(box2, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newBox2.transform.parent = obstacleHolder;

                        instantion1 = newBox2;
                        break;
                    case 'J':
                        GameObject newBox3 = Instantiate(box3, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newBox3.transform.parent = obstacleHolder;

                        instantion1 = newBox3;
                        break;
                    case 'D':
                        GameObject newTerrainDoor = Instantiate(terrain, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newTerrainDoor.transform.parent = terrainHolder;
                        GameObject newDoor = Instantiate(door, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, -2f)), mapBeginingPosition.rotation) as GameObject;
                        newDoor.transform.parent = wallHolder;

                        instantion1 = newTerrainDoor;
                        instantion2 = newDoor;
                        break;
                    case 'K':
                        GameObject newTerrainKey = Instantiate(terrain, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newTerrainKey.transform.parent = terrainHolder;
                        GameObject newKey = Instantiate(key, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 2f)), mapBeginingPosition.rotation) as GameObject;
                        newKey.transform.parent = wallHolder;

                        instantion1 = newTerrainKey;
                        instantion2 = newKey;
                        break;
                    case 'E':
                        GameObject newHollowTerrainEnemy = Instantiate(hollowTerrain, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newHollowTerrainEnemy.transform.parent = terrainHolder;
                        GameObject newEnemy = Instantiate(pinkSlime, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, -2f)), mapBeginingPosition.rotation) as GameObject;
                        newEnemy.transform.parent = enemyHolder;

                        instantion1 = newHollowTerrainEnemy;
                        instantion2 = newEnemy;
                        break;
                }

                if (instantion1 != null)
                {
                    foreach (Transform child in instantion1.transform)
                    {
                        if (child.tag.Equals("Block"))
                        {
                            SpriteRenderer sprite = child.GetComponent<SpriteRenderer>();
                            Debug.Log(child.name);

                            if (sprite != null)
                            {
                                sprite.color = levelColor;
                                Debug.Log(child.name);
                            }
                        }
                    }
                }

                if (instantion2 != null)
                {
                    foreach (Transform child in instantion2.transform)
                    {
                        if (child.tag.Equals("Block"))
                        {
                            SpriteRenderer sprite = child.transform.GetComponent<SpriteRenderer>();

                            if (sprite != null)
                            {
                                sprite.color = levelColor;
                            }
                        }
                    }
                }
            }
        }
    }
}