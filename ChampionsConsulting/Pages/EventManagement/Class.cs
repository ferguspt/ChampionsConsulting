using System.ComponentModel.DataAnnotations;

public class FeedBackModel
{
    [Required(ErrorMessage = "Please select an event")]
    public int EventId { get; set; }

    [Required(ErrorMessage = "Please provide feedback")]
    public string Feedback { get; set; }

    // Other properties related to feedback

    // Methods for processing feedback data

    public void ProcessFeedback()
    {
        // Logic to process and handle the submitted feedback
        // For example, saving to a database, sending notifications, etc.
    }
}
