
namespace TgApp.Model
{

    public class MsgModel
    {
        [SugarColumn(IsPrimaryKey = true)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
    }
}
