using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto1_AYD2.Models
{
    public class protoVehiculo: ICloneable
    {
        [Required(ErrorMessage = "Debe ingresar la marca del vehiculo")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Debe ingresar el modelo del vehiculo")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Debe ingresar la cantidad de CC del motor del vehiculo")]
        public int MotorCC { get; set; }
        [Required(ErrorMessage = "Debe ingresar  el color del vehiculo")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Debe ingresar el tipo del vehiculo")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Debe ingresar una línea de vehículo")]
        public string Linea { get; set; }

        [Required(ErrorMessage = "Debe ingresar la cantidad de ejes")]
        public int CantidadEjes { get; set; }
        [Required(ErrorMessage = "Debe ingresar un tipo de Tracción")]
        public string Traccion { get; set; }

        #region IClonable Members
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }
}