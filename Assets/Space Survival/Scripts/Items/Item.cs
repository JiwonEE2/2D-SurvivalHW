using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	virtual protected void Contact() { }

	virtual protected void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Contact();
			GameManager.Instance.items.Remove(this);
			Destroy(gameObject);
		}
	}
}
