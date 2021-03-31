﻿using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Back.Services.ModeServices
{
    public interface IModeServices
    {
        Task<IEnumerable<Mode>> GetModeListAsync();

        Task<Mode> GetModeByIdAsync(Guid id);

        Task UpdateModeAsync(Guid id, Mode mode);

        Task CreateModeAsync(Mode mode);

        Task DeleteModeAsync(Guid id);
    }
}
