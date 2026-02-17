using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header ("PlayerStats")]
    [SerializeField]
    int health = 100;
    [SerializeField]
    int speed = 15;
    bool levelcomplete = false;
    public int strength = 10;
    string upgrade = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("hi");
    }   

    // Update is called once per frame
    void Update()
    {

        if(levelcomplete == true) {
            if(upgrade == "strength"){
                //strength += upgrade.val;
            }
            else if(upgrade == "health") {
                //health += upgrade.val;
            }
          else if(upgrade == "speed") {
                //speed += upgrade.val;
            }
        }
        //Debug.Log(health);
        //Debug.Log(speed);
        //Debug.Log(strength);
    }
}
