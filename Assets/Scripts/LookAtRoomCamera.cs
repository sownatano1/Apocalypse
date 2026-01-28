using UnityEngine;
using PurrNet;

public class LookAtRoomCamera : PlayerIdentity<LookAtRoomCamera>
{
    private Rigidbody rb;
    private Transform currentRoomCameraPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // ✅ Só o player LOCAL deste cliente executa
        if (!TryGetLocal(out var localPlayer)) return;
        if (localPlayer != this) return;

        if (currentRoomCameraPoint == null) return;

        Vector3 dir = currentRoomCameraPoint.position - rb.position;
        dir.y = 0f; // só Y

        if (dir.sqrMagnitude > 0.0001f)
            rb.rotation = Quaternion.LookRotation(dir);
    }

    public void SetRoomCameraPoint(Transform point)
    {
        // ✅ Só o local pode setar
        if (!TryGetLocal(out var localPlayer)) return;
        if (localPlayer != this) return;

        currentRoomCameraPoint = point;
    }

    public void ClearRoomCameraPoint(Transform point)
    {
        if (!TryGetLocal(out var localPlayer)) return;
        if (localPlayer != this) return;

        if (currentRoomCameraPoint == point)
            currentRoomCameraPoint = null;
    }
}
