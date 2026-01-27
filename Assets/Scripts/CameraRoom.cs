using UnityEngine;
using UnityEngine.UIElements;

public class CameraRoom : MonoBehaviour
{
    [SerializeField] private GameObject cameraGO;
    private Rigidbody player;
    private bool playerDetected = false;

    private void Update()
    {
        if(playerDetected)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
            player.rotation = Quaternion.LookRotation(cameraGO.transform.position - player.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            cameraGO.SetActive(true);
            playerDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraGO.SetActive(false);
            playerDetected = false;
        }
    }
}
