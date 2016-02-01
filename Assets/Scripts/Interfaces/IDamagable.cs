using UnityEngine;
using System.Collections;

public interface IDamagable<T>
{
	void Damage(T DamageTaken);
}
