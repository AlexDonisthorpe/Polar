using UnityEngine;

public class TL_AttachToPlayer : MonoBehaviour
{
    public float Elevation = 9f;
    private Transform Player;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //Force the camera to follow the player
    void FollowPlayer()
    {
        if (Player != null)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + Elevation, Player.transform.position.z - 3f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        FollowPlayer();
    }
}
