namespace ControlMesh.Host
{
    public interface IAuditListener
    {
        Task ListenToAuditQueueAsync();
    }
}