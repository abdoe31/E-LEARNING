﻿using System;
using System.Collections.Generic;

namespace E_Learning.DAL;

public partial class Quize
{
    public int Id { get; set; }

    public string Header { get; set; } = null!;

    public int? Classid { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? Duration { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? Updatedat { get; set; }

    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<UserQuiz> UserQuizzes { get; set; } = new List<UserQuiz>();
}