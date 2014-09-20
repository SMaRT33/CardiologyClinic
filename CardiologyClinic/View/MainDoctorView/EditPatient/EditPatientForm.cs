﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CardiologyClinic.Controller;

namespace CardiologyClinic.View.MainDoctor.EditPatient
{
    public partial class EditPatientForm : Form
    {
        private MainDoctorController mainDoctorController;

        public EditPatientForm()
        {
            InitializeComponent();
        }

        public EditPatientForm(MainDoctorController mainDoctorController)
            : this()
        {
            this.mainDoctorController = mainDoctorController;
        }

        private void save_Click(object sender, EventArgs e)
        {

        }

        private void reset_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
