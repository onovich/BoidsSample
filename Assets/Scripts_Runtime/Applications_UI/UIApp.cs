using System;
using System.Threading.Tasks;
using Boids.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Boids {
    public static class UIApp {

        public static void Init(UIAppContext ctx) {

        }

        public static async Task LoadAssets(UIAppContext ctx) {
            try {
                await ctx.uiCore.LoadAssets();
            } catch (Exception e) {
                GLog.LogError(e.ToString());
            }
        }

        public static void ReleaseAssets(UIAppContext ctx) {
            ctx.uiCore.ReleaseAssets();
        }

        public static void TearDown(UIAppContext ctx) {
            ctx.uiCore.TearDown();
        }

        // Tick
        public static void LateTick(UIAppContext ctx, float dt) {
            ctx.uiCore.LateTick(dt);
        }

        // Panel - Login
        public static void Login_Open(UIAppContext ctx) {
            PanelLoginDomain.Open(ctx);
        }

        public static void Login_Close(UIAppContext ctx) {
            PanelLoginDomain.Close(ctx);
        }

    }

}