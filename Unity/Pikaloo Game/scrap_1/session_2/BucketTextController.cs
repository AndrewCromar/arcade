using UnityEngine;
using UnityEngine.UI;

public class BucketTextController : MonoBehaviour {
    [Header ("References")]
    [SerializeField] private Text TextRef;

    public void SetText(string _setText){ TextRef.text = _setText; }
}