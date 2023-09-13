namespace Library1
{
    public class ServiceResponce <T>
    {
        public T? Data { get; set; }
        public bool? Success { get; set; }
        public string Massage { get; set; } = string.Empty;
    }
}
