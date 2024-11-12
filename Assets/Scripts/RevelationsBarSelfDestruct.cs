public class RevelationsBarSelfDestruct : MonoBehaviour
{
    public float destructionDelay = 2f;
    private GenerateStartEndBars barGenerator;

    private void Start()
    {
        barGenerator = FindObjectOfType<GenerateStartEndBars>();
    }

    private void OnTriggerExit(Collider other)
    {
        // Call the bar generation on the manager before self-destruction
        if (barGenerator != null)
        {
            barGenerator.TriggerBarGeneration(other.transform.position);
        }

        // Destroy this object after a delay
        Destroy(gameObject, destructionDelay);
    }
}
