namespace Notes.DataAccess.NoteConvertor
{
    public interface INoteConverter
    {
        Domian.Models.Note ConvertEntityToNote(Entites.Note note);
        Entites.Note ConvertNoteToEntity(Domian.Models.Note note);
    }
}