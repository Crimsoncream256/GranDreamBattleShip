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
        // ADキーの入力を取得
        float horizontalInput = Input.GetAxis("Horizontal");

        // WSキーの入力を取得
        float verticalInput = Input.GetAxis("Vertical");

        // 入力がある場合、速度を更新
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 inputDirection = new Vector3(horizontalInput, verticalInput, 0f);

            // 速度を加速
            velocity += inputDirection.normalized * acceleration * Time.deltaTime;

            // 最大速度を制限
            velocity = Vector3.ClampMagnitude(velocity, maxMoveSpeed);
        }
        else
        {
            // キーが離れた場合、速度を徐々に減少
            velocity -= velocity.normalized * deceleration * Time.deltaTime;
        }

        // キャラクターを移動させる
        transform.Translate(velocity * Time.deltaTime);
    }
}
