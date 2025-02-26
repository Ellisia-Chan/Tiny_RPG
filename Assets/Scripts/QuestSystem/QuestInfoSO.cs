using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "ScriptableObjects/QuestInfoSO", order = 1)]
public class QuestInfoSO : ScriptableObject {
    [field: SerializeField] public string id { get; private set; }

    [Header("General")]
    [SerializeField] public string displayName;

    [Header("Requirements")]
    [SerializeField] public int levelRequirement;
    [SerializeField] public QuestInfoSO[] questPrerequisites;

    [Header("Steps")]
    [SerializeField] public GameObject[] questStepsPrefabs;

    [Header("Rewards")]
    [SerializeField] public int goldReward;
    [SerializeField] public int expReward;

    // Ensures the name of the scriptable object is the same as the id
    private void OnValidate() {
        #if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}
