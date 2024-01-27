using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float m_WalkSpeed = 10.0f;
    [SerializeField] private float m_SprintModifier = 2.0f;
    [SerializeField] private float m_JumpHeight = 5.0f;

    private Rigidbody m_Rigidbody;
    private float m_TranslationSpeed;
    private float m_StrafeSpeed;

    private void Start()
    {
        if (m_Rigidbody == null)
        {
            m_Rigidbody = GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        HandleWalk();
    }

    private void HandleWalk()
    {
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, out _, transform.localScale.y + 0.5f))
        {
            m_Rigidbody.AddForce(new Vector3(0, m_JumpHeight, 0), ForceMode.VelocityChange);
        }
        
        // Move Direction calcs
        m_TranslationSpeed = Input.GetAxis("Vertical") * m_WalkSpeed * Time.deltaTime;
        m_StrafeSpeed = Input.GetAxis("Horizontal") * m_WalkSpeed * Time.deltaTime;

        if (m_TranslationSpeed > 0.0f || m_StrafeSpeed > 0.0f)
        {
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
        
        // Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_TranslationSpeed *= m_SprintModifier;
        }

        // Apply movement vector
        transform.Translate(m_StrafeSpeed, 0, m_TranslationSpeed);
    }
}
