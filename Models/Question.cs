using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models;

public class Question
{
    public int Id { get; set; }
    //Foreign Key - refering to the Quiz this question belongs to
    public int QuizId { get; set; }
    public string? Text { get; set; }

}