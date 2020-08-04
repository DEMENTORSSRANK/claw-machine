using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class MouseOrbitImproved : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    private Rigidbody _rigidbody;

    private float _x;
    private float _y;

    private void Start()
    {
        var angles = transform.eulerAngles;
        _x = angles.y;
        _y = angles.x;

        _rigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (_rigidbody != null)
        {
            _rigidbody.freezeRotation = true;
        }
    }

    private void LateUpdate()
    {
        if (!target) return;
        // if (Application.isMobilePlatform)
        // {
        //     _x = 
        // }
        if (TryGetTouchPosition.Try(out _))
        {
            _x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            _y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            _y = ClampAngle(_y, yMinLimit, yMaxLimit);
        }
        
        var rotation = Quaternion.Euler(_y, _x, 0);

        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
        // if (Physics.Linecast(target.position, transform.position, out var hit, 1 << 8))
        // {
        //     distance -= hit.distance;
        //     print("sadasdasd");
        // }
        var negDistance = new Vector3(0.0f, 0.0f, -distance);
        var position = rotation * negDistance + target.position;
        
        var t = transform;
        t.rotation = rotation;
        t.localPosition = position;
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}