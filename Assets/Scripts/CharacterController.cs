using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float acceleration = 1.0f;
    public float deceleration = 2.0f;
    public float maxMoveSpeed = 10.0f;

    private Vector3 velocity;

    private void Update()
    {
        // AD�L�[�̓��͂��擾
        float horizontalInput = Input.GetAxis("Horizontal");

        // WS�L�[�̓��͂��擾
        float verticalInput = Input.GetAxis("Vertical");

        // ���͂�����ꍇ�A���x���X�V
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 inputDirection = new Vector3(horizontalInput, verticalInput, 0f);

            // ���x������
            velocity += inputDirection.normalized * acceleration * Time.deltaTime;

            // �ő呬�x�𐧌�
            velocity = Vector3.ClampMagnitude(velocity, maxMoveSpeed);
        }
        else
        {
            // �L�[�����ꂽ�ꍇ�A���x�����X�Ɍ���
            velocity -= velocity.normalized * deceleration * Time.deltaTime;
        }

        // �L�����N�^�[���ړ�������
        transform.Translate(velocity * Time.deltaTime);
    }
}