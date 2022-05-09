using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using VeterinariaExamen.Models;

namespace VeterinariaExamen.ViewModels
{
    public class MascotasViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Mascota> Lista { get; set; } = new ObservableCollection<Mascota>();

        public Mascota Mascota { get; set; }
        public string Vista { get; set; } = "Ver";
        public string Error { get; set; }

        public ICommand CancelarCommand { get; set; }
        public ICommand AgregarCommand { get; set; }
        public ICommand GuardarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }

        //public ICommand GuardarDatosCommand { get; set; }

        public MascotasViewModel()
        {
            AgregarCommand = new RelayCommand(VerAgregar);
            CancelarCommand = new RelayCommand(Cancelar);
            GuardarCommand = new RelayCommand(Guardar);
            EliminarCommand = new RelayCommand(Eliminar);
            //GuardarDatosCommand = new RelayCommand(GuardarDatos);
            CargarDatos();
        }

        private void Eliminar()
        {
            if (Mascota != null)
            {
                Lista.Remove(Mascota);
                GuardarDatos();
            }

        }

        private void Guardar()
        {
            if (Mascota != null)
            {

                Error = "";
                    
                if (string.IsNullOrWhiteSpace(Mascota.Nombre))
                {
                    Error = "Ingresa un nombre valido";
                }


                if (Error == "")
                {
                    Lista.Add(Mascota);
                    GuardarDatos();
                    Cancelar();
                }

                PropertyChange();

            }
        }

        private void Cancelar()
        {
            Vista = "Ver";
            Mascota = null;
            PropertyChange();
        }

        private void VerAgregar()
        {
            Vista = "Agregar";
            Error = "";
            Mascota = new Mascota();
            PropertyChange();
        }

        void GuardarDatos()
        {
            var json = JsonConvert.SerializeObject(Lista);
            File.WriteAllText("mascotas.json", json);
        }

        void CargarDatos()
        {
            try
            {
                var json = File.ReadAllText("mascotas.json");
                Lista = JsonConvert.DeserializeObject<ObservableCollection<Mascota>>(json);

            }
            catch
            {
                Lista = new ObservableCollection<Mascota>();
            }
        }

        void PropertyChange(string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
