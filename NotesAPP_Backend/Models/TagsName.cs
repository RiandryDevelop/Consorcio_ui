using System;
using System.Collections.Generic;

namespace NotesAPP_Backend.Models;

public partial class TagsName
{
    public string? TagName1 { get; set; }

    public string? TagName2 { get; set; }

    public string? TagName3 { get; set; }

    public int TagNameId { get; set; }

    public virtual ICollection<NotesScheme> NotesSchemes { get; } = new List<NotesScheme>();
}
