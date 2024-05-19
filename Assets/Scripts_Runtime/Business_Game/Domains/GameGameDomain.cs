using MortiseFrame.Swing;
using UnityEngine;

namespace Boids {

    public static class GameGameDomain {

        public static void NewGame(GameBusinessContext ctx) {

            var config = ctx.templateInfraContext.Config_Get();

            // Game
            var game = ctx.gameEntity;
            game.fsmComponent.Gaming_Enter();

            // Map
            var mapTypeID = config.originalMapTypeID;
            var map = GameMapDomain.Spawn(ctx, mapTypeID);
            var has = ctx.templateInfraContext.Map_TryGet(mapTypeID, out var mapTM);
            if (!has) {
                GLog.LogError($"MapTM Not Found {mapTypeID}");
            }

            // Boid
            var boidTMArr = mapTM.boidSpawnArr;
            var boidPosArr = mapTM.boidSpawnPosArr;
            var boidAllyStatusArr = mapTM.boidSpawnAllyStatusArr;
            GameBoidDomain.SpawnAll(ctx, boidTMArr, boidPosArr, boidAllyStatusArr);

            // UI

        }

        public static void ExitGame(GameBusinessContext ctx) {
            // Game
            var game = ctx.gameEntity;
            game.fsmComponent.NotInGame_Enter();

            // Map
            GameMapDomain.UnSpawn(ctx);

            // Boid
            int boidLen = ctx.boidRepo.TakeAll(out var boidArr);
            for (int i = 0; i < boidLen; i++) {
                var boid = boidArr[i];
                GameBoidDomain.UnSpawn(ctx, boid);
            }

            // UI
        }

    }
}