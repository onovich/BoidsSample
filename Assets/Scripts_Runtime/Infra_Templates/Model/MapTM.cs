using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Boids {

    [CreateAssetMenu(fileName = "SO_Map", menuName = "Boids/MapTM")]
    public class MapTM : ScriptableObject {

        public int typeID;

        public Vector2 mapSize;
        public Vector2 mapPos;

        // Boid Spawn
        public BoidTM[] boidSpawnArr;
        public Vector2[] boidSpawnPosArr;
        public AllyStatus[] boidSpawnAllyStatusArr;

        // Camera
        public Vector2 cameraConfinerWorldMax;
        public Vector2 cameraConfinerWorldMin;

    }

}