using System;
using System.Collections.Generic;
using UnityEngine;

namespace Boids {

    public class GameBusinessContext {

        // Entity
        public GameEntity gameEntity;
        public MapEntity currentMapEntity;

        public BoidRepository boidRepo;

        // App
        public UIAppContext uiContext;

        // Service
        public IDRecordService idRecordService;
        public RandomService randomService;

        // Infra
        public TemplateInfraContext templateInfraContext;
        public AssetsInfraContext assetsInfraContext;

        // Timer
        public float fixedRestSec;

        // SpawnPoint
        public Vector2 ownerSpawnPoint;

        // TEMP
        public BoidCSModel[] boidCSModelTemp;
        public ComputeBuffer boidBuffer;

        public GameBusinessContext() {
            gameEntity = new GameEntity();
            idRecordService = new IDRecordService();
            randomService = new RandomService();
            boidRepo = new BoidRepository();
        }

        public void Reset() {
            idRecordService.Reset();
            boidRepo.Clear();
            boidBuffer?.Release();
        }

    }

}