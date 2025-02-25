using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "ScriptableObjects/QuestInfoSO", order = 1)]
public class QuestInfoSO : ScriptableObject {
    [field: SerializeField] public string id { get; private set; }

    [Header("General")]
    [SerializeField] private string displayName;

    [Header("Requirements")]
    [SerializeField] private int levelRequirement;
    [SerializeField] private QuestInfoSO[] questPrerequisites;

    [Header("Steps")]
    [SerializeField] private GameObject[] questStepsPrefabs;

    [Header("Rewards")]
    [SerializeField] private int goldReward;
    [SerializeField] private int expReward;

    // Ensures the name of the scriptable object is the same as the id
    private void OnValidate() {
        #if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}
