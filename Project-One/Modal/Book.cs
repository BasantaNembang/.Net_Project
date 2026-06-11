namespace Project_One.Modal
{
    public class Book
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;

        public int BookDetailsId { get; set; }

        public BookDetails? BookDetails { get; set; }
    }
}
//the side/table that has the foreign key is the dependent side/table
//and the other side is should be used to creat DTO and to get data from the database



