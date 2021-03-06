﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardiologyClinic.Bean;
using CardiologyClinic.View.NurseView;
using CardiologyClinic.Service;
using CardiologyClinic.Help;

namespace CardiologyClinic.Controller
{
    public class NurseController
    {
        private User user;
        private NurseForm nurseForm;
        private NurseService nurseService =
            (NurseService)BeanFactory.GetFactory().GetBean("nurseService");

        public NurseController(User user)
        {
            this.user = user;
        }

        public void Start()
        {
            nurseForm = new NurseForm(this);
            nurseForm.ShowNurseName(user.Name);
            nurseForm.Show();
        }

        public void ShowAllPurposesEvent()
        {
            List<Purpose> result = new List<Purpose>();

            ((Nurse)user).Rooms = nurseService.GetRoomsByNurse((Nurse)user);

            foreach (Room room in ((Nurse)user).Rooms)
            {

                room.Patients = nurseService.GetPatientByRoom(room);

                foreach (Patient p in room.Patients)
                {

                    p.Purposes = nurseService.GetPurposesByPatient(p);

                    foreach (Purpose purpose in p.Purposes)
                    {
                        result.Add(purpose);
                    }
                }
            }

            SortPurposes(result);

            nurseForm.ShowPurposes(result);
        }

        public void PutMenuAllRooms()
        {
            nurseForm.ShowMenuRooms(((Nurse) user).Rooms);
        }

        public void PutMenuAllPatients()
        {
            ICollection<Patient> result = new List<Patient>();

            foreach (Room room in ((Nurse)user).Rooms)
            {
                foreach (Patient patient in room.Patients)
                {
                    result.Add(patient);
                }
            }

            nurseForm.ShowMenuPatients(result);
        }

        public void ShowAllRoomsEvent()
        {
            nurseForm.ShowRooms(((Nurse)user).Rooms);
        }

        public void ShowPurposesByRoom(Room room)
        {
            room = nurseService.GetRoomByName(room);

            List<Purpose> result = new List<Purpose>();

            room.Patients = nurseService.GetPatientByRoom(room);

            foreach (Patient p in room.Patients)
            {

                p.Purposes = nurseService.GetPurposesByPatient(p);

                foreach (Purpose purpose in p.Purposes)
                {
                    result.Add(purpose);
                }
            }

            SortPurposes(result);

            nurseForm.ShowPurposes(result);
        }

        public void ShowPurposesByPatient(Patient patient)
        {
            List<Purpose> result = new List<Purpose>();

            patient.Purposes = nurseService.GetPurposesByPatient(patient);

            foreach (Purpose purpose in patient.Purposes)
            {
                result.Add(purpose);
            }

            SortPurposes(result);

            nurseForm.ShowPurposes(result);
        }

        private void SortPurposes(List<Purpose> p)
        {
            for (int i = 0; i < p.Count - 1; i++)
            {
                for (int j = i; j < p.Count; j++)
                {
                    if (p[i].DateOfProcedure > p[j].DateOfProcedure)
                    {
                        Purpose tmp = p[i];
                        p[i] = p[j];
                        p[j] = tmp;
                    }
                }
            }
        }

        public void GetPatientByName(Patient patient)
        {
            this.nurseService.GetPatientByName(patient);
        }

        public void GetRoomByNumber(Room room)
        {
            this.nurseService.GetRoomByName(room);
        }

        public Purpose GetPurposeById(string id)
        {
            return nurseService.GetPurposesById(id);
        }

        public bool SavePurpose(Purpose p)
        {
            return nurseService.SavePurpose(p);
        }
    }
}
