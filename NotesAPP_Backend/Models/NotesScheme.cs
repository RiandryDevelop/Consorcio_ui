using System;
using System.Collections.Generic;

namespace NotesAPP_Backend.Models;

public partial class NotesScheme
{
    public int IdNote { get; set; }

    public string? Owner { get; set; }

    public DateTime? CreationDate { get; set; }

    public bool? IsArchive { get; set; }

    public string? CategoryName { get; set; }

    public int? TagNameId { get; set; }

    public virtual TagsName? TagName { get; set; }
}
