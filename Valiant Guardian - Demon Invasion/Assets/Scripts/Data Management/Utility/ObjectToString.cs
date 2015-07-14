using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
//this class is general data utility to convert c# object - string (vice versa)
//use binary formatter to convert object to binary data.
//then convert binary data to string using base64 string converter.
public static class ObjectToString
{
    //use this method to convert object to string.
	public static string ToString(object obj)
	{
		using (MemoryStream ms = new MemoryStream())
		{
			new BinaryFormatter().Serialize(ms, obj);         
			return Convert.ToBase64String(ms.ToArray());
		}
	}
	
    //use this method to get object from string input.
    //cast object output from this method to get wanted object type
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

