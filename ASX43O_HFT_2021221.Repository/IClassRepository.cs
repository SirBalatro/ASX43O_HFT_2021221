﻿using ASX43O_HFT_2021221.Models;
using System.Linq;

namespace ASX43O_HFT_2021221.Repository
{
    public interface IClassRepository
    {
        void ChangeName(int id, string name);
    }
}