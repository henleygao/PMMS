using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using PMMS.Services.System;
using PMMS.Entities;
using PMMS.Enum;
using PMMS.Exceptions;
using PMMS.Services.Impl.Utils;

namespace PMMS.Services.Impl.System
{
    [UnitOfWork]
    public class UserLogic : IUserLogic
    {
        ISession session;

        public UserLogic(ISession session)
        {
            this.session = session;
        }

        public void AddUser(UserAddView view)
        {
            session.Transaction.Begin();
            User user = new User()
            {
                Account = view.Account,
                Name = view.Name,
                Password = "8888",
                Status = UserStatus.Enable
            };
            session.Save(user);
            session.Transaction.Commit();
        }

        public IList<UserListView> ListUser()
        {
            var query = (from u in session.Query<User>()
                         select new UserListView()
                         {
                             Account = u.Account,
                             Id = u.Id,
                             Name = u.Name,
                             Status = u.Status == UserStatus.Enable ? "启用" : "禁用"
                         });
            return query.ToList();
        }

        public void UpdateUser(UserUpdateView view)
        {
            var user = session.Get<User>(view.Id);
            user.Name = view.Name;
            user.Account = view.Account;
            session.Update(user);
        }

        public List<LoginUserListView> ListLoginUser()
        {
            var query = (from u in session.Query<User>()
                         select new LoginUserListView()
                         {
                             AccountAndName = string.Format("{0}-{1}", u.Account, u.Name),
                             Id = u.Id,
                         });
            return query.ToList();
        }

        public UserView Login(LoginView view)
        {
            var user = LogicUtils.NotNull(session.Get<User>(view.Id));
            if (user.Status == UserStatus.Disable)
            {
                throw new LoginException(LoginFailType.UserIsDisabled);
            }
            if (user.Password != view.Password)
            {
                throw new LoginException(LoginFailType.AccountOrPasswordWrong);
            }
            return new UserView()
            {
                Id = user.Id,
                Name = user.Name
            };
        }

        public void Disable(IList<int> uIds)
        {
            foreach (var id in uIds)
            {
                var user = session.Get<User>(id);
                user.Status = UserStatus.Disable;
                session.Update(user);
            }
        }

        public void Enable(IList<int> uIds)
        {
            foreach (var id in uIds)
            {
                var user = session.Get<User>(id);
                user.Status = UserStatus.Enable;
                session.Update(user);
            }
        }

        public void ResetPassword(IList<int> uIds)
        {
            foreach (var id in uIds)
            {
                var user = session.Get<User>(id);
                user.Password = "8888";
                session.Update(user);
            }
        }

    }
}
