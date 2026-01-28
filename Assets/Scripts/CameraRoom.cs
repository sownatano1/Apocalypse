using Unity.Cinemachine;
using UnityEngine;

public class CameraRoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCameraBase roomCam;

    private void OnTriggerEnter(Collider other)
    {
        var enteredPlayer = other.GetComponentInParent<PlayerRoomCamera>();
        if (enteredPlayer == null) return;

        // ✅ só troca se for o player local desse cliente
        if (!PlayerRoomCamera.TryGetLocal(out var localPlayer)) return;
        if (enteredPlayer != localPlayer) return;

        enteredPlayer.SwitchTo(roomCam);

        var look = other.GetComponentInParent<LookAtRoomCamera>();
        if (look != null)
            look.SetRoomCameraPoint(roomCam.transform);

        var move = other.GetComponentInParent<PlayerMovement>();
        if (move != null)
            move.currentRoomCamera = roomCam.transform;
    }
}
