﻿using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public interface ICongDung
    {
        Task<List<CongDung>> GetCongDungs();
    }
}
