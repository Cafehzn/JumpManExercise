using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float speed = 7f;

    private void Update()
    {
        if (!PlayerController.instance.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

}
