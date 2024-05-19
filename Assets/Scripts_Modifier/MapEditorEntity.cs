using System;
using System.Collections.Generic;
using TriInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Boids.Modifier {

    public class MapEditorEntity : MonoBehaviour {

        [SerializeField] int typeID;
        [SerializeField] GameObject mapSize;
        [SerializeField] MapTM mapTM;
        [SerializeField] Transform boidGroup;
        [SerializeField] Vector2 cameraConfinerWorldMax;
        [SerializeField] Vector2 cameraConfinerWorldMin;

        [Button("Bake")]
        void Bake() {
            BakeMapInfo();
            BakeBoid();

            EditorUtility.SetDirty(mapTM);
            AddressableHelper.SetAddressable(mapTM, "TM_Map", "TM_Map", true);
            AssetDatabase.SaveAssets();
            Debug.Log("Bake Sucess");
        }

        void BakeMapInfo() {
            mapTM.typeID = typeID;
            mapTM.mapSize = mapSize.transform.localScale;
            mapTM.mapPos = mapSize.transform.localPosition;
            mapSize.transform.localScale = mapTM.mapSize;
            mapSize.transform.localPosition = mapTM.mapPos;
        }

        void BakeBoid() {
            List<BoidTM> boidTMList = new List<BoidTM>();
            List<Vector2> boidSpawnPosList = new List<Vector2>();
            List<AllyStatus> boidAllyStatusList = new List<AllyStatus>();
            var boidEditors = boidGroup.GetComponentsInChildren<BoidEditorEntity>();
            if (boidEditors == null) {
                Debug.Log("BoidEditors Not Found");
            }
            for (int i = 0; i < boidEditors.Length; i++) {
                var editor = boidEditors[i];

                var tm = editor.boidTM;
                boidTMList.Add(tm);

                var pos = editor.GetPos();
                boidSpawnPosList.Add(pos);

                var allyStatus = editor.GetAllyStatus();
                boidAllyStatusList.Add(allyStatus);

                editor.index = i;
                editor.Rename();
            }
            mapTM.boidSpawnArr = boidTMList.ToArray();
            mapTM.boidSpawnPosArr = boidSpawnPosList.ToArray();
            mapTM.boidSpawnAllyStatusArr = boidAllyStatusList.ToArray();
        }

        void OnDrawGizmos() {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube((cameraConfinerWorldMax + cameraConfinerWorldMin) / 2, cameraConfinerWorldMax - cameraConfinerWorldMin);
        }

    }

}