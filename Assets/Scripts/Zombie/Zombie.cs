using DefaultNamespace;
using UnityEngine;

public class Zombie : ZombieBase
{
    public Vector3 direction = new Vector3(-1, 0, 0);
    public float speed = .1f;
    
    private bool _isWalking;
    private Animator _animator;
    
    public float damage = 1f;
    public float damageInterval = 2f;
    private float _damageTimer;
    
    private GameObject _headPrefab;
    private bool _isLostHead;
    public float headLostHealth = 5f;
    private bool _isDied;
    
    // Start is called before the first frame update
    void Start()
    {
        _isWalking = true;
        _isLostHead = false;
        _animator = GetComponent<Animator>();
        _isDied = false;
        _headPrefab = gameObject.transform.Find("head").gameObject;
        
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(_isDied)
            return;
        
        if (_isWalking)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(_isDied)
            return;
        
        if (other.CompareTag("Plant"))
        {
            _isWalking = false;
            _damageTimer = 0f;
            _animator.SetBool("Walk", _isWalking);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(_isDied)
            return;
        
        if (other.CompareTag("Plant"))
        {
            _damageTimer += Time.deltaTime;
            if (_damageTimer >= damageInterval)
            {
                var plant = other.GetComponent<PlantBase>();
                plant.ChangeHealth(-damage);
                _damageTimer = 0f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(_isDied)
            return;
        
        if (other.CompareTag("Plant"))
        {
            _isWalking = true;
            _animator.SetBool("Walk", _isWalking);
        }
    }

    public override void ChangeHealth(float num)
    {
        currentHealth = Mathf.Clamp(currentHealth + num, 0, maxHealth);
        if (currentHealth <= 0 && !_isDied)
        {
            _isDied = true;
            _animator.SetTrigger("Die");
            return;
        }
        
        if (currentHealth <= headLostHealth && !_isLostHead)
        {
            _isLostHead = true;
            _animator.SetBool("LostHead", _isLostHead);
            _headPrefab.SetActive(true);
        }
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }
}
