using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehavior{
	
	[SerializeField]
	GameObject[] switches;

	[SerializField]
	GameObject exitDoor;

	int noSwitches = 0;

	[SerializeField]
	Text switchCount;

	public void LoadNextLevel(int x){
	SceneManager.LoadScene(x);
	}

	void Start(){
		GetNoOfSwitches();
	}

	public int GetNoOfSwitches(){
		int x = 0;
		for (int i = 0; i < switches.Length; i++){
			if (switches[i].GetComponent<Switch>().isOn == false){
				x++;
			}
			else if (switches[i].GetComponent<Switch>().isOn == true){
				noSwitches--;
			}

			noSwitches = x;
		}
	}
}