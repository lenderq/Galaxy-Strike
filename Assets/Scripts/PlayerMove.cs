using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float controlSpeed = 40f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;

    [SerializeField] float controllRollFactor = 20f;
    [SerializeField] float controllPitchFactor = 40f;
    [SerializeField] float rotationSpeed = 10f;

    Vector3 movement;
    void Start()
    {

    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    private void ProcessRotation()
    {
        float rotate = controllRollFactor * -movement.x;
        float pitch = controllPitchFactor * -movement.y;
        Quaternion rotationOffset = Quaternion.Euler(pitch, 0f, rotate);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, rotationOffset, rotationSpeed * Time.deltaTime);
    }
}
