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
using System.Configuration;

namespace PMMS.Services.Impl.System
{
    [UnitOfWork]
    public class UserLogic : IUserLogic
    {
         string DefaultPassword = ConfigurationManager.AppSettings["DefaultPassword"].ToString();
         string AdminAccount = ConfigurationManager.AppSettings["AdminAccount"].ToString();
        ISession session;
      
        public UserLogic(ISession session)
        {
            this.session = session;
        }

        public void InitUser()
        {
            var user = (from u in session.Query<User>()
                        where u.Account == AdminAccount
                        select u).FirstOrDefault();

            if (user == null)
            {
                user = new User()
                {
                    Account = AdminAccount,
                    Name = "管理员",
                    Password = DefaultPassword,
                    Status = UserStatus.Enable
                };
                session.Save(user);
            }
        }


        public void AddUser(UserAddView view)
        {
            var user = (from u in session.Query<User>()
                        where u.Account == view.Account
                        select u).FirstOrDefault();
            if (user != null)
                throw new RepeatException();

            session.Transaction.Begin();
            user = new User()
           {
               Account = view.Account,
               Name = view.Name,
               Password = DefaultPassword,
               Status = UserStatus.Enable
           };
            session.Save(user);
            session.Transaction.Commit();
        }

        public IList<UserListView> ListUser()
        {
            var query = (from u in session.Query<User>()
                         where u.Account != AdminAccount
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
            var plus = (from u in session.Query<User>()
                        where u.Account == view.Account && u.Id != view.Id
                        select u).FirstOrDefault();
            if (plus != null)
                throw new RepeatException();

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
                user.Password = DefaultPassword;
                session.Update(user);
            }
        }

    }
}
