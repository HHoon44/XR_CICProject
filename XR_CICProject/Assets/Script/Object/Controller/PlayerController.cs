using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace CIC_Project_Object
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private CameraController camController;

        [SerializeField]
        private Character player;

        /// 나중에 Actor 클래스 만들어서 거기서 캐릭터 + 몬스터 공동 작업 처리하면 좋을듯
        [SerializeField]
        private Animator charAnim;

        [SerializeField]
        private float moveSpeed;        // 이동 속도

        private bool isMove;            // 이동 가능 여부
        private Vector3 destination;    // 목적지 값

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;

                // 마우스 클릭한 지점에 레이를 발사하여 벡터 값을 가져옵니다
                if (Physics.Raycast(camController.cam.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    destination = hit.point;
                    isMove = true;
                }
            }

            Move();
        }

        /// <summary>
        /// 캐릭터 이동 메서드
        /// </summary>
        private void Move()
        {
            if (isMove)
            {
                if (Vector3.Distance(destination, player.transform.position) <= .5f)
                {
                    isMove = false;
                    charAnim.SetBool("isRun", isMove);
                    return;
                }

                // 목적지 좌표를 구하기 위해서 클릭 지점 - 캐릭터 위치를 합니다
                var dir = destination - transform.position;

                // 캐릭터 회전 작업 && 캐릭터 이동 작업 
                player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.LookRotation(dir), 5f * Time.deltaTime);   
                transform.position += dir.normalized * Time.deltaTime * moveSpeed;

                charAnim.SetBool("isRun", isMove);
            }
        }
    }
}