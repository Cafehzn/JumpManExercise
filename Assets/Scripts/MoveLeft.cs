using UnityEngine;
using UnityEngine.InputSystem;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float speed = 7f;

    private Rigidbody rb;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
