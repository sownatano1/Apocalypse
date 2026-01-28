using PurrNet;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerRoomCamera : PlayerIdentity<PlayerRoomCamera>
{
    private GameObject currentCamGO;

    public void SwitchTo(CinemachineVirtualCameraBase newCam)
    {
        if (newCam == null) return;

        if (currentCamGO != null)
            currentCamGO.SetActive(false);

        newCam.gameObject.SetActive(true);
        currentCamGO = newCam.gameObject;
    }
}
