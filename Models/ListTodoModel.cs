namespace VampireMedia.Models
{
    public class ListTodoModel
    {
        public int Id { get; set; } 
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Completed { get; set; }  
        public string? ItemDescription { get; set; }
        

    }
}
