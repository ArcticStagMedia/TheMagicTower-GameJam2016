using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour
{
    public float MovementSpeed;

    Rigidbody2D rgb2d;
    // Use this for initialization
    void Start()
    {
        GameManager.Instance.PlaySFX(0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * MovementSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyOne" || other.gameObject.tag == "EnemyThree")
        {
            Camera.main.GetComponent<Spawn>().BugKilled();
            GameManager.Instance.BugDeathSFX();
            Destroy(other.gameObject);
            GameManager.Instance.Score++;
            Destroy(this.gameObject);
        }
    }
}
