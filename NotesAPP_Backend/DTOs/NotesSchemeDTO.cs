namespace NotesAPP_Backend.DTOs
{
    public class NotesSchemeDTO
    {
        public int IdNote { get; set; }

        public string? Owner { get; set; }

        public string? CreationDate { get; set; }

        public bool? IsArchive { get; set; }

        public string? CategoryName { get; set; }

        public int? TagNameId { get; set; }
    }
}
