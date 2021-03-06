﻿using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	private const float MAX_COOLDOWN = 0.1f;
	//Starting position
	public int StartX;
	public int StartY;
	//Cooldown biar karakternya gak running like crazy
	private float cooldown;
	//Movement of the character, one must be straight and one must be inverted
	public enum Movement { Straight, Inverted};
	public Movement moveDir;
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
		map = GameController.map;
		now.x = StartX;
		now.y = StartY;
		//Put he character to the right position
		this.transform.position = ( new Vector3( StartX + 0.5f, StartY + 0.5f, 0));

	}

	// Update is called once per frame
	void Update () {

		if (cooldown > 0) {
			cooldown -= Time.deltaTime;
		} else {
			if (Input.GetKey (KeyCode.UpArrow)) {
				Debug.Log ("(" + now.x + "," + now.y + ")");
				if(moveDir == Movement.Straight){
					MoveUp ();
				}
				else{
					MoveDown ();
				}
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				Debug.Log ("(" + now.x + "," + now.y + ")");
				if(moveDir == Movement.Straight){
					MoveDown();
				}
				else{
					MoveUp ();
				}
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				Debug.Log ("(" + now.x + "," + now.y + ")");
				if(moveDir == Movement.Straight){
					MoveRight ();
				}
				else{
					MoveLeft ();
				}
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				Debug.Log ("(" + now.x + "," + now.y + ")");
				if(moveDir == Movement.Straight){
					MoveLeft ();
				}
				else{
					MoveRight ();
				}
			}
		}
	}

	void MoveRight(){
		if (now.x < GameController.mapWidth - 1 && map [now.x, now.y] != Grid.Type.right && map [now.x, now.y] != Grid.Type.bottomRight) {
			this.transform.Translate (1f, 0, 0);
			now.x++;
			cooldown = MAX_COOLDOWN;
		}
	}

	void MoveLeft(){
		if (now.x > 0 && map [now.x - 1, now.y] != Grid.Type.right && map [now.x - 1, now.y] != Grid.Type.bottomRight) {
			this.transform.Translate (-1f, 0, 0);
			now.x--;
			cooldown = MAX_COOLDOWN;
		}
	}

	void MoveUp(){
		if (now.y < GameController.mapHeight - 1 && map [now.x, now.y + 1] != Grid.Type.bottom && map [now.x, now.y + 1] != Grid.Type.bottomRight) {
			this.transform.Translate (0, 1f, 0);
			now.y++;
			cooldown = MAX_COOLDOWN;
		}
	}

	void MoveDown(){
		if (now.y > 0 && map [now.x, now.y] != Grid.Type.bottom && map [now.x, now.y] != Grid.Type.bottomRight) {
			this.transform.Translate (0, -1f, 0);
			now.y--;
			cooldown = MAX_COOLDOWN;
		}
	}
}
