using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Vector3 currentTarget;
    protected Vector3 player_pos;
    [SerializeField]
    protected GameObject diamonds;

    protected Animator animator;
    protected SpriteRenderer sp;
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems; //only inherited classes can modify, outside scripts cannot see it (private)
    [SerializeField]
    protected Transform pointA, pointB; //waypoints for AI behavior
    protected bool isHit = false;
    protected bool isDead = false;
    protected Transform player;
    private float distance;
    //player stored variable

    public virtual void Init()
    {
        transform.position = pointA.position;
        animator = GetComponent<Animator>();
        if (GameObject.FindGameObjectWithTag("Player").transform != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

        }
        else if (GameObject.FindGameObjectWithTag("PlatformerPlayer").transform != null)
        {
            player = GameObject.FindGameObjectWithTag("PlatformerPlayer").transform;

        }
        sp = GetComponent<SpriteRenderer>();
    }
    public virtual void Attack() //virtual keyword allows for functino to be rewritten
    {
        Debug.Log("My name is " + this.gameObject.name);
    }

    public virtual void Update()
    {
        player_pos = transform.position;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !animator.GetBool("InCombat"))
        {
            return;
        }

        if (isDead == false)
        {
            Movement();

        }

    }

    public void Start()
    {
        Init();
    }

    public virtual void Movement()
    {

        //change direction in combat
        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (animator.GetBool("InCombat") == true && direction.x > 0)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if (animator.GetBool("InCombat") && direction.x < 0)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);

        }

        //ai movement path
        if (currentTarget == pointA.position)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);

        }

        else if (currentTarget == pointB.position)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);

        }
        if (transform.position == pointA.position)
        {
            Debug.Log("At Point A");
            animator.SetBool("Idle", true);
            currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            Debug.Log("At Point B");
            animator.SetBool("Idle", true);
            currentTarget = pointA.position;
        }

        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        //Checking when to reset incombat mode
        distance = Mathf.Abs(transform.position.x - player.position.x);

        if (distance > 5)
        {
            isHit = false;
            animator.SetBool("InCombat", false);
        }


    }

    public virtual void Damage()
    {
        if (isDead == true)
        {
            return;
        }
        Debug.Log("Damage");
        Debug.Log("Health is at " + health);
        health = health - 1;
        if (health < 1)
        {
            isDead = true;
            for (var i = 0; i < gems; i++)
            {
                Instantiate(diamonds, new Vector3(player_pos.x + Random.Range(-1f, 1f), player_pos.y, 0), Quaternion.identity);
            }
            animator.SetTrigger("Death");
            //spawn a diamond
            //change value of diamond to gem count

            // Destroy(this.gameObject);
        }

        animator.SetTrigger("Hit");
        isHit = true;
        animator.SetBool("InCombat", true);
    }



}
