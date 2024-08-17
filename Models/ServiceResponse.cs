namespace SolarpayAPI.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; } = default(T)!;  // Инициализация по умолчанию для устранения предупреждения
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;  // Инициализация пустой строкой
    }
}
