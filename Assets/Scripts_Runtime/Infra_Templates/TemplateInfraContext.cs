using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Boids {

    public class TemplateInfraContext {

        GameConfig config;
        public AsyncOperationHandle configHandle;

        Dictionary<int, MapTM> mapDict;
        public AsyncOperationHandle mapHandle;

        Dictionary<int, BoidTM> boidDict;
        public AsyncOperationHandle boidHandle;

        public TemplateInfraContext() {
            mapDict = new Dictionary<int, MapTM>();
            boidDict = new Dictionary<int, BoidTM>();
        }

        // Game
        public void Config_Set(GameConfig config) {
            this.config = config;
        }

        public GameConfig Config_Get() {
            return config;
        }

        // Map
        public void Map_Add(MapTM map) {
            mapDict.Add(map.typeID, map);
        }

        public bool Map_TryGet(int typeID, out MapTM map) {
            var has = mapDict.TryGetValue(typeID, out map);
            if (!has) {
                GLog.LogError($"Map {typeID} not found");
            }
            return has;
        }

        // Boid
        public void Boid_Add(BoidTM Boid) {
            boidDict.Add(Boid.typeID, Boid);
        }

        public bool Boid_TryGet(int typeID, out BoidTM Boid) {
            var has = boidDict.TryGetValue(typeID, out Boid);
            if (!has) {
                GLog.LogError($"Boid {typeID} not found");
            }
            return has;
        }

        // Clear
        public void Clear() {
            mapDict.Clear();
            boidDict.Clear();
        }

    }

}