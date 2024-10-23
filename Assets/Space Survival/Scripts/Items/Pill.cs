using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : Item
{
	private void Start()
	{
		GameManager.Instance.items.Add(this);
	}

	override protected void Contact()
	{
		// �÷��̾� ü�� ȸ��
		GameManager.Instance.player.hp = GameManager.Instance.player.maxHp;
	}
}
