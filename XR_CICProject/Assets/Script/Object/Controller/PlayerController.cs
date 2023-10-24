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

        /// ���߿� Actor Ŭ���� ���� �ű⼭ ĳ���� + ���� ���� �۾� ó���ϸ� ������
        [SerializeField]
        private Animator charAnim;

        [SerializeField]
        private float moveSpeed;        // �̵� �ӵ�

        private bool isMove;            // �̵� ���� ����
        private Vector3 destination;    // ������ ��

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;

                // ���콺 Ŭ���� ������ ���̸� �߻��Ͽ� ���� ���� �����ɴϴ�
                if (Physics.Raycast(camController.cam.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    destination = hit.point;
                    isMove = true;
                }
            }

            Move();
        }

        /// <summary>
        /// ĳ���� �̵� �޼���
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

                // ������ ��ǥ�� ���ϱ� ���ؼ� Ŭ�� ���� - ĳ���� ��ġ�� �մϴ�
                var dir = destination - transform.position;

                // ĳ���� ȸ�� �۾� && ĳ���� �̵� �۾� 
                player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.LookRotation(dir), 5f * Time.deltaTime);   
                transform.position += dir.normalized * Time.deltaTime * moveSpeed;

                charAnim.SetBool("isRun", isMove);
            }
        }
    }
}