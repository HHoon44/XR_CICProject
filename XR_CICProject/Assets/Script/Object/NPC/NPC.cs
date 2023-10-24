using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private Collider coll;

    private void Update()
    {
        AreaChecking();
    }

    private void AreaChecking()
    {
        var colls = Physics.OverlapBox(coll.bounds.center, coll.bounds.extents, transform.rotation,
            1 << LayerMask.NameToLayer("Player"));

        Debug.Log(colls.Length);

        if (colls.Length == 0)
        {
            return;
        }

        // �÷��̾� �̵��� ���� ����? �ϳ� �ۼ��ϸ� �ɵ�
        // �÷��̾�� NPC�� ��ȣ�ۿ��� �Ͼ�� ����

    }
}