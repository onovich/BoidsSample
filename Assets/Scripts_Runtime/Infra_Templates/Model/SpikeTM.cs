using System;
using UnityEngine;

namespace Boids {

    [CreateAssetMenu(fileName = "SO_Spike", menuName = "Boids/SpikeTM")]
    public class SpikeTM : ScriptableObject {

        public int typeID;
        public Sprite mesh;

    }

}