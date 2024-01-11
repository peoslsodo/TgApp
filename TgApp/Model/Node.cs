namespace TgApp.Model
{
    public class Node
    {
        public int ParentId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string FormName { get; set; }

        public bool IsRoot { get; set; }
    }
}
