using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventName : ScriptableObject
{
	/// <summary>
	/// name of event
	/// </summary>
	public string n
	{
		get { return this.ToString(); }
	}
}