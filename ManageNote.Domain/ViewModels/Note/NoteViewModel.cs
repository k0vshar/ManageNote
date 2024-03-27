using System.ComponentModel.DataAnnotations;

namespace ManageNote.Domain.ViewModels.Note
{
    public class NoteViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Введите название заголовка")]
        [MinLength(3, ErrorMessage = "Минимальная длина должна быть больше трёх символов")]
        public string? Title { get; set; }

        [Display(Description = "Введите текст заметки")]
        [MinLength(10, ErrorMessage = "Минимальная длина должна быть больше 10 символов")]
        public string? Description { get; set; }
    }
}
