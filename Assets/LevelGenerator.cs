using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	public GameObject templateClear;
	public GameObject templateBottom;
	public GameObject templateRight;
	public GameObject templateBottomRight;
	public TextAsset level;

	void Start () {
		var Player = GameObject.FindGameObjectsWithTag ("Player");

		LevelParser parser = new LevelParser (level);
		int width = parser.getInt();
		int height = parser.getInt();
		parser.getInt ();
		var kiriAtas = new Vector2 (0.5f, 0.5f);
		Grid.Type[,] map = new Grid.Type[width,height];
		for (int i=height-1; i>=0; i--) {
			for (int j=0; j<width; j++) {
				int type = parser.getInt();
				Vector3 pos = new Vector3(kiriAtas.x + (float)j, kiriAtas.y + (float)i, 1);
				switch (type) {
				case 0: 
					map[j,i] = Grid.Type.clear;
					GameObject.Instantiate(templateClear, pos, Quaternion.identity);
					break;
				case 1:
					//map[j,i] = Grid.Type.bottom;
					map[j,i] = Grid.Type.clear;
					GameObject.Instantiate(templateBottom, pos, Quaternion.identity);
					break;
				case 2:
					//map[j,i] = Grid.Type.right;
					map[j,i] = Grid.Type.clear;
					GameObject.Instantiate(templateRight, pos, Quaternion.identity);
					break;
				case 3:
					//map[j,i] = Grid.Type.bottomRight;
					map[j,i] = Grid.Type.clear;
					GameObject.Instantiate(templateBottomRight, pos, Quaternion.identity);
					break;
				}
			}
			parser.getInt ();
		}
		Camera.main.GetComponent<GameController> ().map = map;
		Debug.Log ("Map has been loaded");

		foreach (GameObject Char in Player) {
			Char.GetComponent<CharacterMovement>().enabled = true;
			Char.GetComponent<CharacterMovement>().initialize ();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
