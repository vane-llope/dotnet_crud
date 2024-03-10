namespace crud.Models;

public static class UserRepository
{
    private static List<UserModel> _users = new List<UserModel>()
  {
    new UserModel {UserId = 1 ,Name = "John"},
    new UserModel {UserId = 2 ,Name = "Max"},
    new UserModel {UserId = 3 ,Name = "Shaun"},
    new UserModel {UserId = 4 ,Name = "ponyo"},
    new UserModel {UserId = 5 ,Name = "Mario"},
    new UserModel {UserId = 6 ,Name = "Luigi"},
    new UserModel {UserId = 7 ,Name = "Sara"},
    new UserModel {UserId = 8 ,Name = "Peter"},
    new UserModel {UserId = 9 ,Name = "Percy"},
    new UserModel {UserId = 10 ,Name = "Anna"},
  };

    public static List<UserModel> GetUsers() => _users;
   public static UserModel? GetUserById(int UserId)
    {
        var user = _users.FirstOrDefault(x => x.UserId == UserId);
        if (user != null)
        {
            return new UserModel
            {
                UserId = user.UserId,
                Name = user.Name
            };
        }
        return null;
    }

    public static void AddUser(UserModel user){
        var maxId = _users.Max(x => x.UserId);
        user.UserId = maxId+1;
        _users.Add(user);
    }

    public static void UpdateUser(int UserId,UserModel user){
        if(UserId != user.UserId) return;
        var userToUpdate = _users.FirstOrDefault(x => x.UserId == UserId);
        if(userToUpdate != null){
         userToUpdate.Name = user.Name;
        }
    }

    public static void DeleteUser(int UserId){
         var user = _users.FirstOrDefault(x => x.UserId == UserId);
         if(user != null){
            _users.Remove(user);
         }
    }
}
