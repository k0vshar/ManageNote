using ManageNote.DAL.Interfaces;
using ManageNote.Domain.Entity;
using ManageNote.Domain.Enum;
using ManageNote.Domain.Response;
using ManageNote.Domain.ViewModels.Note;
using ManageNote.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManageNote.Service.Implementation
{
    internal class NoteService : INoteService
    {
        private readonly IBaseRepository<Note> _noteRepository;

        public NoteService(IBaseRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IBaseResponse<Note>> CreateNote(long id, NoteViewModel model)
        {
            try
            {
                var note = new Note()
                {
                    Title = model.Title,
                    Description = model.Description
                };

                await _noteRepository.Create(note);

                return new BaseResponse<Note>()
                {
                    StatusCode = StatusCode.OK,
                    Data = note
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Note>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Note>> EditNote(long id, NoteViewModel model)
        {
            try
            {
                var note = await _noteRepository.GetAllNotes().FirstOrDefaultAsync(x => x.Id == id);
                if (note == null)
                {
                    return new BaseResponse<Note>()
                    {
                        Description = "Найдено 0 заметок",
                        StatusCode = StatusCode.NoteNotFound
                    };
                }

                note.Description = model.Description;
                note.Title = model.Title;

                await _noteRepository.Update(note);


                return new BaseResponse<Note>()
                {
                    Data = note,
                    StatusCode = StatusCode.OK,
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<Note>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        IBaseResponse<List<Note>> INoteService.GetNotes()
        {
            try
            {
                var notes = _noteRepository.GetAllNotes().ToList();
                if (!notes.Any())
                {
                    return new BaseResponse<List<Note>>()
                    {
                        Description = "Найдено 0 заметок",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Note>>()
                {
                    Data = notes,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Note>>()
                {
                    Description = $"[GetNotes] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<NoteViewModel>> ViewNote(long id)
        {
            try
            {
                var note = await _noteRepository.GetAllNotes().FirstOrDefaultAsync(x => x.Id == id);
                if (note == null)
                {
                    return new BaseResponse<NoteViewModel>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.NoteNotFound
                    };
                }

                var data = new NoteViewModel()
                {
                    Description = note.Description,
                    Title = note.Title
                };

                return new BaseResponse<NoteViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<NoteViewModel>()
                {
                    Description = $"[ViewNote] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteNote(long id)
        {
            try
            {
                var note = await _noteRepository.GetAllNotes().FirstOrDefaultAsync(x => x.Id == id);
                if (note == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Note not found",
                        StatusCode = StatusCode.NoteNotFound,
                        Data = false
                    };
                }

                await _noteRepository.Delete(note);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[Delete] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
