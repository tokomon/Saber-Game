using Laser2D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{

    public Texture3D texture;
    public Material matPisoE;

    public static Material matPiso;
    public static Material matPared;

    public LaserLogic laserLogic;
    public System.Random rnd = new System.Random();

    static void UpdateObjects(LaserLogic logic)
    {
        int pos;
        foreach (Cube cube in logic.CubesLeft)
        {
            long elapsedTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - cube.TimeStamp;
            pos = (int)(logic.Speed * elapsedTime / 1000f);

            // actualiza la posición de un cubo
            cube.CubeObject.transform.position = new Vector3(0, 0, pos); //position the newly created quad accordingly
        }
        foreach (Cube cube in logic.CubesRight)
        {
            long elapsedTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - cube.TimeStamp;
            pos = (int)(logic.Speed * elapsedTime / 1000f);

            // actualiza la posición de un cubo
            cube.CubeObject.transform.position = new Vector3(5, 0, pos); //position the newly created quad accordingly
        }
    }

    // Use this for initialization
    void Start()
    {
        laserLogic = new LaserLogic(5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        long elapsedTime;
        int pos;
        if (laserLogic.CubesLeft.Count != 0)
        {
             elapsedTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - laserLogic.CubesLeft.Peek().TimeStamp;
             pos = (int)(laserLogic.Speed * elapsedTime / 1000f);
            if (pos < 6)
            {
                UpdateObjects(laserLogic);
            }
            else
            {
                //objects.Peek().GetComponent<Renderer>().material = matPisoE;
                Destroy(laserLogic.CubesLeft.Peek().CubeObject);
                laserLogic.RemoveLeft();
            }

        }

        if (laserLogic.CubesRight.Count != 0)
        {
            elapsedTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - laserLogic.CubesRight.Peek().TimeStamp;
            pos = (int)(laserLogic.Speed * elapsedTime / 1000f);
            if (pos < 6)
            {
                UpdateObjects(laserLogic);
            }
            else
            {
                //objects.Peek().GetComponent<Renderer>().material = matPisoE;
                Destroy(laserLogic.CubesRight.Peek().CubeObject);
                laserLogic.RemoveRight();
            }
        }

        if (rnd.Next(3) == 2)
            laserLogic.TryToAddCube();
        //////
        /*
        gameStatus = GenGameStatus(logic);
        Console.WriteLine(logic.Speed);
        PrintScreen(gameStatus);
        gameStatus = GenGameStatus(logic);
        if (gameStatus[0, 19] == 'O')
            logic.RemoveLeft();
        if (gameStatus[1, 19] == 'O')
            logic.RemoveRight();

        if (rnd.Next(3) == 2)
            logic.TryToAddCube();
        Thread.Sleep(17);
        Console.Clear();
        */

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

}






