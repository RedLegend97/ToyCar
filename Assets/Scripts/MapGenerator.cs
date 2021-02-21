using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class MapGenerator : MonoBehaviour
{
    #region MapGenObjects

    public GameObject prevCeiling;
    public GameObject prevFloor;
    public GameObject ceiling;
    public GameObject floor;
    public GameObject playerPos;

    public GameObject trap;
    public GameObject laserWall;

    #endregion


    // Update is called once per frame
    void Update()
    {
        GenerateGround();
        //GenerateObstacles();
    }

    /// <summary>
    /// PCG Function
    /// </summary>
    void GenerateGround()
    {
        if (playerPos.transform.position.x > floor.transform.position.x)
        {
            //Endless ground and ceiling generation

            var tempCeiling = prevCeiling;
            var tempFloor = prevFloor;
            tempFloor = Instantiate(tempFloor,
                new Vector3(floor.transform.position.x + 100, floor.transform.position.y, floor.transform.position.z),
                Quaternion.identity);
            tempCeiling = Instantiate(tempCeiling,
                new Vector3(ceiling.transform.position.x + 100, ceiling.transform.position.y,
                    ceiling.transform.position.z), Quaternion.identity);
            Destroy(prevCeiling);
            Destroy(prevFloor);
            prevCeiling = ceiling;
            prevFloor = floor;
            ceiling = tempCeiling;
            floor = tempFloor;

            //Obstacle part of generation

            var tempTrap = trap;
            var tempLaserWall = laserWall;
            //Trap generation part
            tempTrap = Instantiate(tempTrap, new Vector3
            (prevFloor.transform.position.x + Random.Range(75, 150), prevFloor.transform.position.y + 31.23f,
                prevFloor.transform.position.z), Quaternion.identity);
            //LaserWall Generation part
            tempLaserWall = Instantiate(tempLaserWall, new Vector3(
                prevFloor.transform.position.x + Random.Range(75, 150),
                prevFloor.transform.position.y + 31.66f,
                prevFloor.transform.position.z), Quaternion.identity);
            //TODO PREVIOUS ONES MAY BE DESTROYED LATER
            // Destroy(trap);
            // Destroy(laserWall);

           // trap = tempTrap;
            //laserWall = tempLaserWall;
        }
    }
}