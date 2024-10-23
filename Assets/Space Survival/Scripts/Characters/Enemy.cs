using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	//public float maxHp = 10f;//�ϼ�
	private float maxHp;
	public float hp = 10f; //ü��
	public float damage = 10f; //���ݷ�
	public float moveSpeed = 3f; //�̵� �ӵ�

	//�ʰ���
	public float hpAmount { get { return hp / maxHp; } } //���� ���Ǵ� �׸��� ������Ƽ�� �����

	//Getter/Setter

	private Transform target; //������ ���

	public Image hpBar;

	private void Start()
	{
		GameManager.Instance.enemies.Add(this);   // �� ����Ʈ�� �ڱ� �ڽ��� �߰�
		target = GameManager.Instance.player.transform;
		maxHp = hp;
	}

	private void Update()
	{
		Vector2 moveDir = target.position - transform.position;
		Move(moveDir.normalized);
		//print(moveDir.magnitude);//vector.magnitude:�ش� ���Ͱ� "���⺤��"�� ���ֵ� ��, ������ ����
		//print(moveDir.normalized);//������ ������ä ���̰� 1�� ������ ����.
		hpBar.fillAmount = hpAmount;
	}

	public void Move(Vector2 dir)//dir ���� Ŀ���� 1�� ������ �ϰ� �������=>normalized
	{
		transform.Translate(dir * moveSpeed * Time.deltaTime);
	}

	//OnHit, ...
	public void TakeDamage(float damage)
	{
		hp -= damage;

		if (hp <= 0) //���� ���
		{
			Die();
		}
	}

	private void Die()
	{
		GameManager.Instance.enemies.Remove(this);
		GameManager.Instance.player.killCount++;
		Destroy(gameObject);
	}

	public float damageInterval = 1000f;    // ������ ����
	private float preDamageTime = 0;    // ������ �������� �� �ð�(Time.time)




	private void OnCollisionStay2D(Collision2D collision)
	{
		// �÷��̾�� ������ �ִ� ���� �����ϱ�
		if (collision.collider.CompareTag("Player"))
		{
			preDamageTime += Time.deltaTime;
			print(preDamageTime);
			if (damageInterval <= preDamageTime)
			{
				collision.collider.GetComponent<Player>().TakeDamage(damage);
				preDamageTime = 0;
			}
		}
	}
}