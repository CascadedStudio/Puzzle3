using UnityEngine;
using System.Collections;

public class Grid{
	public enum Type {clear, bottom, right, bottomRight};

	private Type gtype;

	public Type gridType {
		get {
			return gtype;
		}
		set {
			if (value != Type.clear && value != Type.bottom && value != Type.right && value != Type.bottomRight) {
				gtype = Type.clear;
			}
		}
	}
}
