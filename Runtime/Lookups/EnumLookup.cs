using System;
using System.Linq;

[Serializable]
public sealed class EnumLookup<K, V> : Lookup<K, V> where K : Enum
{
	protected override K[] GetKeys() =>
		Enum.GetValues(typeof(K)).Cast<K>().ToArray();

	protected override void Process(SerializedDictionary<K, V> lookup)
	{
		for (int i = lookup.Count - 1; i >= 0; i--)
		{
			var key = lookup.Keys.ElementAt(i);

			if (!Enum.IsDefined(typeof(K), key))
				lookup.Remove(key);
		}
	}
}