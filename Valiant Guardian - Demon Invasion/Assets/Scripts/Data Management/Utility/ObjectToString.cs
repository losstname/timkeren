using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class ObjectToString
{
	public static string ToString(object obj)
	{
		using (MemoryStream ms = new MemoryStream())
		{
			new BinaryFormatter().Serialize(ms, obj);         
			return Convert.ToBase64String(ms.ToArray());
		}
	}
	
	public static object ToObject(string base64String)
	{    
		byte[] bytes = Convert.FromBase64String(base64String);
		using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
		{
			ms.Write(bytes, 0, bytes.Length);
			ms.Position = 0;
			return new BinaryFormatter().Deserialize(ms);
		}
	}
}

