using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomMaterial : MonoBehaviour {

    public List<Material> materials;

    private MeshRenderer _renderer;
	// Use this for initialization
	void Start () {
        int rng = Mathf.FloorToInt(Random.Range(0.0f, 100.0f * (materials.Count - 1))) % materials.Count;
        _renderer = this.GetComponent<MeshRenderer>();

        _renderer.material = materials[rng];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
