﻿using System;
using System.Collections.Generic;

namespace E_Learning.DAL;

public partial class UserAssighment
{
    public int Id { get; set; }

    public string? Studentid { get; set; }

    public int? Assighmentid { get; set; }

    public string? Comment { get; set; }

    public bool? Solved { get; set; }

    public bool? Checked { get; set; }
    public string UserAnswerFilePath { get; set; } = null!;

    public virtual Assighment? Assighment { get; set; }

    public virtual User? Student { get; set; }
}
