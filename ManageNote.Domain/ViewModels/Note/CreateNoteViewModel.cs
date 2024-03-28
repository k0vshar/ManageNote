using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageNote.Domain.ViewModels.Note
{
    public class CreateNoteViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Введите заголовок заметки")]
        [MinLength(3, ErrorMessage = "Заголовок заметки должен содержать минимум 3 символа")]
        public string? Title { get; set; }

        [Display(Name = "Введите желаемый текст заметки")]
        [MinLength(10, ErrorMessage = "Текст заметки должен содержать минимум 10 символов")]
        public string? Description { get; set; }
    }
}
