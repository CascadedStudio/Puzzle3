using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	//Starting position
	public int StartX;
	public int StartY;
	//Movement of the character, one must be straight and one must be inverted
	public enum Movement { Straight, Inverted};
	public Movement moveDir;
	private int Move;
	//Map of the area
	private Grid.Type[,] map;
	//Get the current position
	public struct Position{ 
		public int x;
		public int y;
	}
	private Position now;
	// Use this for initialization

	void Start () {
		this.enabled = false;
	}

	public void initialize() {
		//Get the map
		Debug.Log ("Game controller is getting the map");
		map = Camera.main.GetComponent<GameController>().map;
		now.x = StartX;
		now.y = StartY;
		//Put he character to the right position
		this.transform.position = ( new Vector3( StartX + 0.5f, StartY + 0.5f, 0));
		
		//Adjust the movement
		switch(moveDir){
		case Movement.Straight:
			Move = 1;
			break;
		case Movement.Inverted:
			Move = -1;
			break;
		}
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.UpArrow)){
			if(map[now.x,now.y - 1] != Grid.Type.bottom && map[now.x, now.y -1] != Grid.Type.bottomRight){
				this.transform.Translate (0, 1f * Move,0);
				now.y--;
				StartCoroutine (Delay ());
			}
		}
		else if(Input.GetKey (KeyCode.DownArrow)){
			if(map[now.x,now.y] != Grid.Type.bottom && map[now.x, now.y] != Grid.Type.bottomRight){
				this.transform.Translate (0, -1f * Move,0);
				now.y++;
				StartCoroutine (Delay ());
			}
		}
		else if(Input.GetKey (KeyCode.RightArrow)){
			if(map[now.x,now.y] != Grid.Type.right && map[now.x, now.y] != Grid.Type.bottomRight){
				this.transform.Translate (1f * Move,0,0);
				now.x++;
				StartCoroutine (Delay ());
			} 
		}
		else if(Input.GetKey (KeyCode.LeftArrow)){
			if(map[now.x - 1,now.y] != Grid.Type.right && map[now.x - 1, now.y] != Grid.Type.bottomRight){
				this.transform.Translate (-1f * Move,0,0);
				now.x--;
				StartCoroutine (Delay ());
			}
		}
	}
	//Delay each input by 0.1 second
	IEnumerator Delay(){
			yield return new WaitForSeconds(0.1f);
	}
}
