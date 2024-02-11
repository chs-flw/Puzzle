using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialDefaults : MonoBehaviour{

    private static MaterialDefaults _instance;

    public static MaterialDefaults instance {

        get {

            return _instance;

        }

        private set {

            _instance = value;

        }

    }

    [SerializeField]
    private Material _defaultLineMaterial;

    public Material defaultLineMaterial {

        get {

            return _defaultLineMaterial;

        }

    }

    void Awake() {

        if (instance == null) {

            instance = this;

        } else {

            Destroy(this);

        }

    }

}
