﻿using System;

namespace Domain.ApplicationModule.Accounts
{
    public static class AccountService
    {
        public static bool ControleerOfLoginBestaat(IGebruikerRepository repos, string loginNaam)
        {
            var gebr = repos.GetByLogin(loginNaam);

            return gebr != null;
        }
    }
}
