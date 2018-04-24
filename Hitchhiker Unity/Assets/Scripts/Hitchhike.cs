using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hitchhike : MonoBehaviour {

	// Public Variables
	public Slider weather;
	public Slider population;
	public Text percent;
	public Text success;

	// Private Variables
	private float percent_value;

	void Update () {
		float weather_chance = weather.value;
		float population_chance = population.value;
		percent_value = calculate_chance(weather_chance, population_chance) * 100.0f;
		percent.text = percent_value + "%";
	}

	// Calculate Hitchhike success chance
	float calculate_chance (float weather_chance, float population_chance) {
		float chance = weather_chance * population_chance;
		return chance;
	}

	// See if the Hitchhike is successful
	public void success_or_fail() {
		float chance = Random.Range(0.0f, 100.0f);
		if (chance <= percent_value) {
			success.text = "Success!!";
		} else {
			success.text = "Fail :(";
		}
	}
}
