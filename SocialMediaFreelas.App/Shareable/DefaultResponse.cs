public class DefaultResponse<T> where T : IDefaultEntity
{
    public bool Success { get; set; }
    public List<T> Body { get; set; }
    public string ErrorMessage { get; set; }
}