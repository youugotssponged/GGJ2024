using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float m_WalkSpeed = 10.0f;
    [SerializeField] private float m_JumpHeight = 5.0f;

    private Rigidbody m_Rigidbody;
    private float m_TranslationSpeed;
    private float m_StrafeSpeed;
    
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private void Start()
    {
        if (m_Rigidbody == null)
        {
            m_Rigidbody = GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        HandleWalk(Time.deltaTime);
    }
    
    private void HandleWalk(float deltaTime)
    {
        // Jumping
        var localTransform = transform;
        bool isTouchingGroundThisFrame = Physics.Raycast(localTransform.position, Vector3.down, out _, localTransform.localScale.y + 0.5f);
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGroundThisFrame)
        {
            m_Rigidbody.AddForce(new Vector3(0, m_JumpHeight, 0), ForceMode.VelocityChange);
        }
        
        // Move Direction calcs
        m_TranslationSpeed = Input.GetAxis("Vertical") * m_WalkSpeed * deltaTime;
        m_StrafeSpeed = Input.GetAxis("Horizontal") * m_WalkSpeed * deltaTime;

        if (m_TranslationSpeed != 0.0f || m_StrafeSpeed  != 0.0f)
        {
            _animator.SetBool(IsWalking, true);
        }
        else
        {
            _animator.SetBool(IsWalking, false);
        }
        
        // Apply movement vector
        transform.Translate(m_StrafeSpeed, 0, m_TranslationSpeed);
    }
}
