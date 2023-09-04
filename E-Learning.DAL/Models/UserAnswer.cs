using System;
using System.Collections.Generic;

namespace E_Learning.DAL;

public partial class UserAnswer
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int? QuestionId { get; set; }

    public int? UserQuizId { get; set; }

    public bool? Right { get; set; }
    public int? Answerid { get; set; }
    public virtual Question? Question { get; set; }
    public virtual Answer? answer { get; set; }
    public virtual User? User { get; set; }

    public virtual UserQuiz? UserQuiz { get; set; }
}
