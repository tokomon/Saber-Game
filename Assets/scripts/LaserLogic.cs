﻿using System;
using System.Collections.Generic;

namespace Laser2D
{
    public class LaserLogic
    {
        public Queue<Cube> CubesLeft { get; }
        public Queue<Cube> CubesRight { get; }
        public float CubeSize { get; }
        public float Speed { get; }
        long LastCubeTimeLeft;
        long LastCubeTimeRight;

        public LaserLogic(float speed = 1.0f)
        {
            CubesLeft = new Queue<Cube>();
            CubesRight = new Queue<Cube>();

            CubeSize = 1.0f;
            Speed = speed;

            LastCubeTimeLeft = LastCubeTimeRight = 0;
        }

        public void TryToAddCube()
        {
            Random rnd = new Random();
            bool left = CheckLastLeft();
            bool right = CheckLastRight();

            int prob = rnd.Next(100);
            // Try to add cubes in both queues.
            if (left && right)
            {
                int doubleProb = rnd.Next(100);
                if (doubleProb < 5) // 30
                {

                    Cube cube = new Cube();
                    CubesLeft.Enqueue(cube);
                    LastCubeTimeLeft = cube.TimeStamp;

                    cube = new Cube();
                    CubesRight.Enqueue(cube);
                    LastCubeTimeRight = cube.TimeStamp;
                    return;
                }
            }
            // Add a cube in one of the queues.
            if (prob < 7) // 45
            {
                if (prob < 3 && left)
                {
                    Cube cube = new Cube();
                    CubesLeft.Enqueue(cube);
                    LastCubeTimeLeft = cube.TimeStamp;
                }

                else if (right)
                {
                    Cube cube = new Cube();
                    CubesRight.Enqueue(cube);
                    LastCubeTimeRight = cube.TimeStamp;
                }
            }
        }

        public bool CheckLastLeft()
        {
            if (CubesLeft.Count == 0)
                return true;

            long elapsedTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - LastCubeTimeLeft;
            return elapsedTime * Speed >= CubeSize;
        }

        public bool CheckLastRight()
        {
            if (CubesRight.Count == 0)
                return true;

            long elapsedTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - LastCubeTimeRight;
            return elapsedTime * Speed >= CubeSize;
        }

        public void RemoveLeft()
        {
            if (CubesLeft.Count != 0)
                CubesLeft.Dequeue();
        }

        public void RemoveRight()
        {
            if (CubesRight.Count != 0)
                CubesRight.Dequeue();
        }

    }
}
