﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardiologyClinic.Service
{
    interface MainDoctorService
    {
        List<Bean.MedicalProcedure> GetAllMedicalProcedures();
    }
}
