using UnityEngine;
using System.Collections;

public class MeleeImp : MonoBehaviour {
	public float speed = 1f;
    private bool ableMove = true;
	private Transform gateBase;
	private Transform playerBase;
	public Transform sightStart, sightEnd;
	private bool moveToDoor = false;
	private bool foundGate = false;

    public float CoolDown = 2f;

    private Animator anim;
    private int isDeadHash = Animator.StringToHash("isDead");
    private int isAttackingHash = Animator.StringToHash("isAttacking");
    private int isStayingHash = Animator.StringToHash("isStaying");

    private SpriteRenderer enemySpriteRenderer;
    public float fadeSpeed = 1f;
    public float fadeDelay = 2f;

	private int attackX;
	private int defenseY;
    private int hitPoints;

    void Awake() {
        //get hitpoints from databases
        hitPoints = DataEnemy.getInstance().MeleeImp.Hitpoints;
    }

	void Start(){
		gateBase = GameObject.FindGameObjectWithTag ("Base").transform;
		playerBase = GameObject.Find ("PlayerBase").transform;
        anim = GetComponent<Animator>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update () {
		if(ableMove){
			float step = Time.deltaTime * speed;
			//use LineCast to see if enemy get contact to invisWall
			//if got contact to invisWall LayerMask then enemy will move to door instead move toward left
			moveToDoor = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("InvisWall"));
			//un-Comment debug below to see LineCast on Enemy
			//Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
			if(moveToDoor && !foundGate){
				transform.position = Vector3.MoveTowards(transform.position, gateBase.position, step);
			}else if(foundGate){
				if(!ScriptableObject.FindObjectOfType<Door>().isAttackAble()){
					transform.position = Vector3.MoveTowards(transform.position, playerBase.position, step);
                    anim.SetBool(isStayingHash, false);
				}
			}else{
				gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
			}
		}
		if(transform.position == playerBase.position && gameObject.tag != "DeadEnemy"){
			ScriptableObject.FindObjectOfType<PlayerBase>().AttackPlayer();
            Death();
		}
	}

    void disableBeingTargeted()
    {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");
        for (int i = 0; i < heroes.Length; i++)
        {
            heroes[i].GetComponent<Hero>().autoChangeEnemy();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        //when found the door
		if(other.tag == "Base"){
            anim.SetBool(isStayingHash, true);
			foundGate = true;
			moveToDoor = false;
            StartCoroutine(AttackingBase());
		}
    }

    IEnumerator AttackingBase()
    {
		while (true)
        {
            //set animation to attacking base
            anim.SetTrigger(isAttackingHash);
            yield return new WaitForSeconds(CoolDown);
        }
    }

    public void BaseAttacked()
    {
        //get attack damage from databases
        int attackDamage = DataEnemy.getInstance().MeleeImp.AttackDamage;
		attackX = Random.Range(1,30);
        int baseHpDecrease = attackDamage - ((attackDamage * attackX) / 100);
		if(ScriptableObject.FindObjectOfType<Door>().isAttackAble())
				ScriptableObject.FindObjectOfType<Door>().AttackBase(baseHpDecrease);

    }

	public void Attacked(){
        //get defense from databases
        int defense = DataEnemy.getInstance().MeleeImp.Defense;
		attackX = Random.Range(1,20);
		defenseY = Random.Range(31, 80);
        int hpDecrease = HeroAttack.archerAtk - ((HeroAttack.archerAtk * attackX) / 100) - ((defense * defenseY) / 100);
        hitPoints -= hpDecrease;
        if (hitPoints <= 0)
		{
			Death();
            disableBeingTargeted();
		}
	}

    void Death()
    {
        //make the enemy to stop moving
        ableMove = false;
        //let the projectile get through
        GetComponent<BoxCollider2D>().enabled = false;
        //untagged this enemy
        gameObject.tag = "DeadEnemy";
        //add coin
        Coin coin = GameObject.FindObjectOfType<Coin>();
        coin.addCoin();
        anim.SetTrigger(isDeadHash);
        //Destory dead enemy after 2s
        StartCoroutine(FadeOut());
        Destroy(gameObject, 3f);
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(fadeDelay);
        while (true)
        {
            Color newColor = enemySpriteRenderer.color;
            newColor.a -= (Time.deltaTime * fadeSpeed);
            enemySpriteRenderer.color = newColor;
            yield return new WaitForEndOfFrame();
        }
    }

    void OnMouseDown()
    {
        //order heroes to target self
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");
        for (int i = 0; i < heroes.Length; i++)
        {
            heroes[i].GetComponent<Hero>().changeEnemy(this.gameObject);
        }
    }
}