using UnityEngine;
using System.Collections;
using System.IO;

public class LevelParser{

	private StringReader reader;

	public LevelParser(TextAsset t) {
		reader = new StringReader (t.text);
	}

	/*
	 * 		Membaca satu int dari string
	 */
	public int getInt() {
		int ret = 0;
		int c;
		c = reader.Read();
		while (c != -1 && c < (int)'0' && c > (int)'9') {
			c = reader.Read();		
		}
		while (c != -1 && c >= (int)'0' && c <= (int)'9') {
			ret = ret * 10 + (c - (int)'0');		
			c = reader.Read();
		}
		return ret;
	}

	public void Close() {
		reader.Close();
	}
}
