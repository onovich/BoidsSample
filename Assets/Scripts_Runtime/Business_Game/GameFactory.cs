using UnityEngine;

namespace Boids {

    public static class GameFactory {

        public static MapEntity Map_Spawn(TemplateInfraContext templateInfraContext,
                                 AssetsInfraContext assetsInfraContext,
                                 int typeID) {

            var has = templateInfraContext.Map_TryGet(typeID, out var mapTM);
            if (!has) {
                GLog.LogError($"Map {typeID} not found");
            }

            var prefab = assetsInfraContext.Entity_GetMap();
            var map = GameObject.Instantiate(prefab).GetComponent<MapEntity>();
            map.Ctor();
            map.typeID = typeID;
            map.mapSize = mapTM.mapSize;
            map.mapOffset = mapTM.mapPos;

            map.SetSize(map.mapSize);

            return map;
        }

        public static BoidEntity Boid_Spawn(TemplateInfraContext templateInfraContext,
                                 AssetsInfraContext assetsInfraContext,
                                 IDRecordService idRecordService,
                                 RandomService randomService,
                                 int typeID,
                                 Vector2 pos,
                                 AllyStatus allyStatus) {

            var has = templateInfraContext.Boid_TryGet(typeID, out var boidTM);
            if (!has) {
                GLog.LogError($"Boid {typeID} not found");
            }

            var prefab = assetsInfraContext.Entity_GetBoid();
            var boid = GameObject.Instantiate(prefab).GetComponent<BoidEntity>();
            boid.Ctor();

            // Base Info
            boid.entityID = idRecordService.PickBoidEntityID();
            boid.typeID = typeID;
            boid.allyStatus = allyStatus;

            // Set Attr
            boid.hp = boidTM.hpMax;
            boid.hpMax = boidTM.hpMax;

            // Set Pos
            boid.Pos_SetPos(pos);

            // Set Rotation
            var rot = randomService.Rotation();
            boid.transform.rotation = rot;

            // Set Velocity
            float speed = (boidTM.minSpeed + boidTM.maxSpeed) / 2;
            boid.Velocity_Set(boid.transform.up * speed);

            // Set Mesh
            boid.Mesh_Set(boidTM.mesh);
            var color = randomService.Color();
            boid.Mesh_SetColor(color);

            // Set Trail
            boid.Trail_SetColor(color);

            // Set FSM
            boid.FSM_EnterIdle();

            // Set VFX
            boid.deadVFXName = boidTM.deadVFX.name;
            boid.deadVFXDuration = boidTM.deadVFXDuration;

            return boid;
        }

    }

}