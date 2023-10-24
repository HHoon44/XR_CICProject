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

        // 플레이어 이동을 막을 로직? 하나 작성하면 될듯
        // 플레이어와 NPC의 상호작용이 일어나는 로직

    }
}