﻿using DataBaseLayer.Notes;
using ReposatoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReposatoryLayer.Interfaces
{
    public interface INoteRL
    {
        Task AddNote(NotesPostModel notesPostModel, int UserID);
        Task<Note> UpdateNote(int userId, int noteId, NoteUpdateModel noteUpdateModel);
        Task DeleteNote(int noteId, int userId);

        Task ChangeColour(int userId, int noteId, string colour);

        Task ArchiveNote(int userId, int noteId);
    }
}