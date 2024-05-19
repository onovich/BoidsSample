using System;
using UnityEngine;

namespace Boids {

    [CreateAssetMenu(fileName = "SO_Block", menuName = "Boids/BlockTM")]
    public class BlockTM : ScriptableObject {

        public int typeID;
        public Sprite mesh;

    }

}