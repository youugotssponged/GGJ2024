using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float m_Sensitivity = 5.0f;
    [SerializeField] private float m_Smoothing = 2.0f;

    [SerializeField] private float m_yClampMin = -30.0f;
    [SerializeField] private float m_yClampMax = 80.0f;
    
    private Vector2 m_MouseLook;
    private Vector2 m_SmoothingVector;
    
    private bool CursorIsLocked;
    private static bool StopMouseMovement = false;
    
    
    private void Start()
    {
        CursorIsLocked = true;
        SetCursorLockState(CursorIsLocked);
    }

    private void Update()
    {
        if (!StopMouseMovement)
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            mouseDelta = Vector2.Scale(mouseDelta,
                new Vector2(m_Sensitivity * m_Smoothing, m_Sensitivity * m_Smoothing));

            m_SmoothingVector.x = Mathf.Lerp(m_SmoothingVector.x, mouseDelta.x, 1f / m_Smoothing);
            m_SmoothingVector.y = Mathf.Lerp(m_SmoothingVector.y, mouseDelta.y, 1f / m_Smoothing);

            m_MouseLook += m_SmoothingVector; // incrementally add look direction after smoothing per frame

            m_MouseLook.y = Mathf.Clamp(m_MouseLook.y, m_yClampMin, m_yClampMax);
            transform.localRotation = Quaternion.AngleAxis(-m_MouseLook.y, Vector3.right); // Rotate camera
            transform.parent.localRotation = Quaternion.AngleAxis(m_MouseLook.x, Vector3.up); // Rotate everything

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CursorIsLocked = !CursorIsLocked; // Invert on each escape press
                SetCursorLockState(CursorIsLocked);
            }
        }
    }

    public static void SetMouseMovementOff() => StopMouseMovement = true;
    public static void SetMouseMovementOn() => StopMouseMovement = false;
    
    public static void SetCursorLockState(bool locked)
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
        
        Cursor.lockState = CursorLockMode.None;
    }
}
