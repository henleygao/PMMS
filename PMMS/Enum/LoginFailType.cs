namespace PMMS.Enum
{
    public enum LoginFailType
    {
        /// <summary>
        /// 帐号或密码错误
        /// </summary>
        AccountOrPasswordWrong,

        /// <summary>
        /// 用户已禁用
        /// </summary>
        UserIsDisabled,

        /// <summary>
        /// 没有权限登录
        /// </summary>
        NotPrivilegeToLogin
    }
}