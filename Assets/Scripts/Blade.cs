using UnityEngine;
using UnityEngine.Events;

public class Blade : MonoBehaviour
{
    private Camera mainCamera;
    private  Collider bladeCollider;
    private bool slicing;
    public UnityEvent Slicing;
    public Vector3 direction { get; private set; }
    public float sliceForce = 5f;
    public float minSliceVelocity = 0.01f;
    private void Awake()
    {
        mainCamera = Camera.main;
        bladeCollider = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        StopSlicing();
    }
    private void OnDisable()
    {
        StopSlicing();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if (slicing)
        {
            ContinueSlicing();
        }
    }
    private void StartSlicing()
    {
        //SoundManager.instance.PlayFX(0);
        Slicing.Invoke();
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 15f;

        transform.position = newPosition;
        slicing = true;
        bladeCollider.enabled = true;
    }
    private void StopSlicing()
    {
        slicing = false;
        bladeCollider.enabled = false;
    }
    private void ContinueSlicing()
    {        
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
    }
}
