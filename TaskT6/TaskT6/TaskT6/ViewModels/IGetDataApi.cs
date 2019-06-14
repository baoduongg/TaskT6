using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace TaskT6.ViewModels
{
    public interface IGetDataApi
    {
        [Get("/users?id={id}")]
        Task<List<User>> GetUser(string id);

        [Get("/users?email={email}")]
        Task<List<User>> GetUserEmail(string email);

        [Get("/users")]
        Task<ObservableCollection<User>> GetUserName();

        [Get("/photos?albumId={brand}")]
        Task<ObservableCollection<Photo>> GetImages(string brand);
        
        [Get("/albums?id={brand}")]
        Task<List<Albums>> GetAlbum(string brand);


     

    }
}
