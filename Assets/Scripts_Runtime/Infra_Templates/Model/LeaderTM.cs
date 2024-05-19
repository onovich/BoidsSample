using System;
using UnityEngine;

namespace Boids {

    [CreateAssetMenu(fileName = "SO_Leader", menuName = "Boids/LeaderTM")]
    public class LeaderTM : ScriptableObject {

        [Header("Base Info")]
        public int typeID;

        [Header("Attr")]
        public float moveSpeed;
        public float rotationSpeed;

        [Header("Render")]
        public Sprite mesh;
        public Color color;

        [Header("VFX")]
        public GameObject deadVFX;
        public float deadVFXDuration;

    }

}