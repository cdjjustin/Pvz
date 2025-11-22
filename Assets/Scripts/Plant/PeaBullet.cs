using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 direction;
    public float speed = 5f;
    public float damage = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            var zombie = other.GetComponent<ZombieBase>();
            zombie.ChangeHealth(-damage);
            Destroy(gameObject);
        }
    }
}
