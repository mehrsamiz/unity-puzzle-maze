using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        // offset را با چرخش پلیر هماهنگ می‌کنیم
        Vector3 rotatedOffset = target.rotation * offset;

        Vector3 desiredPosition = target.position + rotatedOffset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // دوربین به پلیر نگاه کند (اختیاری ولی توصیه‌شده)
        transform.LookAt(target);
    }
}
