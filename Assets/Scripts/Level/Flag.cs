using UnityEngine;

public class Flag : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField] private ResultingPanel _resultingPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMovement player))
        {
            player.enabled = false;
            collision.attachedRigidbody.velocity = new Vector2(0, collision.attachedRigidbody.velocity.y);

            _resultingPanel.gameObject.SetActive(true);
            _resultingPanel.GetResults(true);
        }
    }
}
