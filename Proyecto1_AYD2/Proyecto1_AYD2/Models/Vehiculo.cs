using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1_AYD2.Models
{
    public class Vehiculo:prtVehiculo
    {

        public string ColorChasis;
        public int MotorCC;
        public int CantidadEjes;
        public string Linea;
        public string Modelo;
        public string Marca;
        public string Traccion;

        /// <summary>
        /// 
        /// </summary>
        public Vehiculo(string colorChasis, int motorCC, int cantidadEjes, string linea, string modelo, string marca, string traccion)
        {
            this.ColorChasis = colorChasis;
            this.Modelo = modelo;
            this.Linea = linea;
            this.CantidadEjes = cantidadEjes;
            this.Marca = marca;
            this.Traccion = traccion;
            this.MotorCC = motorCC;
        }

        public prtVehiculo Clonar()
        {
            return (prtVehiculo)MemberwiseClone();
        }
    }
}