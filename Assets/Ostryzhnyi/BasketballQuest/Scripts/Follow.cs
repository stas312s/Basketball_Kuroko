using UnityEngine;

namespace Ostryzhnyi.BasketballQuest.Scripts
{
    
    public class Follow : MonoBehaviour
    {
        public Transform target;
        public float followSpeed = 5f;
        public Vector3 offSet;

        void Start()
        {
            transform.position = target.position + offSet;
        }
    }
}
