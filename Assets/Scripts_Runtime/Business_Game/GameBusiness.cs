using UnityEngine;

namespace Boids {

    public static class GameBusiness {

        public static void Init(GameBusinessContext ctx) {
            Physics2D.IgnoreLayerCollision(LayConst.ROLE, LayConst.ROLE, true);
        }

        public static void StartGame(GameBusinessContext ctx) {
            GameGameDomain.NewGame(ctx);
        }

        public static void ExitGame(GameBusinessContext ctx) {
            GameGameDomain.ExitGame(ctx);
        }

        public static void Tick(GameBusinessContext ctx, float dt) {

            PreTick(ctx, dt);

            const float intervalTime = 0.01f;
            ref float restSec = ref ctx.fixedRestSec;
            restSec += dt;
            if (restSec < intervalTime) {
                FixedTick(ctx, restSec);
                restSec = 0;
            } else {
                while (restSec >= intervalTime) {
                    restSec -= intervalTime;
                    FixedTick(ctx, intervalTime);
                }
            }
            LateTick(ctx, dt);

        }

        static void PreTick(GameBusinessContext ctx, float dt) {
        }

        static void FixedTick(GameBusinessContext ctx, float dt) {

            var game = ctx.gameEntity;
            var status = game.fsmComponent.status;
            if (status == GameStatus.Gaming) {

                // Boids
                //// CS
                //// 临时代码
                var playerBoidTypeID = 1;
                GameBoidDomain.ProcessCS(ctx, playerBoidTypeID, dt);

                //// FSM
                var boidLen = ctx.boidRepo.TakeAll(out var boidArr);
                for (int i = 0; i < boidLen; i++) {
                    var boid = boidArr[i];
                    GameBoidFSMController.TickFSM(ctx, boid, dt);
                }

                Physics2D.Simulate(dt);

                // Raycast

            }

        }

        static void LateTick(GameBusinessContext ctx, float dt) {

            var game = ctx.gameEntity;
            var status = game.fsmComponent.status;
            if (status == GameStatus.Gaming || status == GameStatus.GameOver) {

                // Boids
                var boidLen = ctx.boidRepo.TakeAll(out var boidArr);
                for (int i = 0; i < boidLen; i++) {
                    var boid = boidArr[i];
                    GameBoidDomain.CheckAndUnSpawn(ctx, boid);
                }

                // Camera

                // UI

            }
            // VFX

            // FPS
            FPSHelper.Tick(dt);
        }

#if UNITY_EDITOR
        public static void OnGUI(bool showFPS) {
            if (!showFPS) {
                return;
            }
            FPSHelper.OnGUI();
        }

#endif

        public static void TearDown(GameBusinessContext ctx) {
            var game = ctx.gameEntity;
            var status = game.fsmComponent.status;
            if (status == GameStatus.Gaming) {
                ExitGame(ctx);
            }
        }

    }

}