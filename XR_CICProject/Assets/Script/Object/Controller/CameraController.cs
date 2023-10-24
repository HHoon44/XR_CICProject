using UnityEngine;

namespace CIC_Project_Object
{
    public class CameraController : MonoBehaviour
    {
        public Camera cam { get; private set; }

        [SerializeField]
        private Transform camPos;

        void Start()
        {
            cam = Camera.main;

            cam.transform.position = camPos.position;
            cam.transform.forward = camPos.forward;
        }
    }
}