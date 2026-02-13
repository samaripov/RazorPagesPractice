using System.ComponentModel;

namespace QuizApp.Models;

public class AnswerOption
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string Text { get; set; } = "Blank";
    [DisplayName("Correct Answer")]
    public bool isCorrect { get; set; } = false;
    public Question Question { get; set; } = default!;
}