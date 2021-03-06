﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardiologyClinic.Bean;

namespace CardiologyClinic.Dao
{
    interface NurseDao
    {
        void Save(Nurse nurse);
        Nurse GetNurseByName(Nurse nurse);
        IList<Nurse> GetAllNurse();
        User GetNurseByPass(string pass);
        Nurse GetNurseByRoom(Room room);
        Nurse GetNurseById(string id);
        void DeleteNurse(string id);
    }
}
