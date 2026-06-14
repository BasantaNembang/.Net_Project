using Project_One.DTO;

namespace Project_One.Service.Interfaces
{
    public interface IOneToMany
    {
        Task<AuthorDTO> CreateAuthorAsync(AuthorDTO author);
        Task<List<AuthorDTO>> GetAllAuthorsAsync();

        Task<AuthorDTO> GetAuthorByIDAsync(int id);

        Task<string> UpdateTheBodyAysnc(int id, AuthorDTO authorDTO);

        Task<string> DeleteData(int id);


    }
}






