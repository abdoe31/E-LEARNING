﻿using System;
using System.Collections.Generic;

namespace E_Learning.DAL;

public partial class UserLecture
{
    public int Id { get; set; }

    public string? StudentId { get; set; }

    public int? Lectureid { get; set; }
     public   AcessType AcessType { get; set; } 

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    public bool QuizRequired { get; set; }

    public int? Duration { get; set; }

    public virtual Lecture? Lecture { get; set; }

    public virtual User? Student { get; set; }
}
