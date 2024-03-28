using ManageNote.Domain.ViewModels.Note;
using ManageNote.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManageNote.Controllers.Note
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        private readonly List<NoteViewModel> notes = new List<NoteViewModel>();

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            var response = _noteService.GetNotes();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteNote(long id)
        {
            await _noteService.DeleteNote(id);
            return RedirectToAction("GetNotes");
        }

        public IActionResult Compare() => PartialView();

        [HttpGet]
        public async Task<ActionResult> ViewNote(long id, bool isJson)
        {
            var response = await _noteService.ViewNote(id);
            if (isJson)
            {
                return Json(response.Data);
            }
            return PartialView("ViewNote", response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> ViewNote(long term)
        {
            var response = await _noteService.ViewNote(term);
            return Ok(response.Data);
        }

        [HttpGet("search")]
        public IActionResult SearchNote(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest("Ключевое слово не может быть пустым");
            }

            var foundNotes = notes.Where(n => n.Title.Contains(keyword) || n.Description.Contains(keyword)).ToList();
            return Ok(foundNotes);
        }


        [HttpGet]
        public async Task<IActionResult> CreateNote(long id)
        {
            if (id == 0)
            {
                return View();
            }

            var response = await _noteService.ViewNote(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote(NoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    await _noteService.CreateNote(model);
                }
                else
                {
                    await _noteService.EditNote(model.Id, model);
                }
            }

            return RedirectToAction("GetNotes");
        }
    }
}
