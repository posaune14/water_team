using UnityEngine;

public class enemy_damage : MonoBehaviour
{
    public GameObject Enemy;
    int enemy_health = 10; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("slash hit enemy " + collision.gameObject.name);
            enemy_health -= 1;
            Debug.Log("enemy health: " + enemy_health);
            if(enemy_health <= 0){
                Enemy.SetActive(false);
            }
        }

    
    void Update()
    {

    }
}
