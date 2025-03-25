namespace EchoFlowApi.Models;

public class Message
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public Users User { get; set; }
    public string RoomId { get; set; }
    public Room Room { get; set; }
    public string Content { get; set; }
    public DateTime MessageDateTime { get; set; }
}
