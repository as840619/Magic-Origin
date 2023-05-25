using UnityEngine;

namespace Object.Bullets
{
    public class BulletFire : MonoBehaviour
    {
        [Header("基本數值")]
        public float bSpeed = 5;

        private Rigidbody2D _bVelocity;


        private void Awake()
        {
        }
    }
}
