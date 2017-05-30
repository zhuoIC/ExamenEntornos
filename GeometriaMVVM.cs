using System;
using System.Windows.Input;
//----------------------------
using System.ComponentModel;

namespace Wpf_ExamenEntornos
{
    class GeometriaMVVM: INotifyPropertyChanged
    {
        Rectangulo _rectangulo;
        Circunferencia _circunferencia;
        string _ladoMayor = "15";
        string _ladoMenor = "12";
        string _radio = "5";
        string _mensaje = "<sin datos>";

        public string AreaRectangulo
        {
            get
            {
                if (_rectangulo != null)
                {
                    return Math.Round(_rectangulo.Area, 2).ToString(); 
                }
                else
                {
                    return "";
                }
            }
        }

        public string Perimetro
        {
            get
            {
                if (_rectangulo != null)
                {
                    return Math.Round(_rectangulo.Perimetro, 2).ToString(); 
                }
                else
                {
                    return "";
                }
            }
        }

        public string AreaCircunferencia
        {
            get
            {
                if (_circunferencia != null)
                {
                    return Math.Round(_circunferencia.Area, 2).ToString() ;  
                }
                else
                {
                    return "";
                }
            }
        }

        public string Longitud
        {
            get
            {
                if (_circunferencia != null)
                {
                    return Math.Round(_circunferencia.Perimetro, 2).ToString(); 
                }
                else
                {
                    return "";
                }
            }
        }

        public string LadoMayor
        {
            get { return _ladoMayor; }
            set 
            {
                if (value != _ladoMayor)
                {
                    _ladoMayor = value;
                }
            }
        }

        public string LadoMenor
        {
            get { return _ladoMenor; }
            set
            {
                if (value != _ladoMenor)
                {
                    _ladoMenor = value;
                }
            }
        }

        public string Radio
        {
            get { return _radio; }
            set
            {
                if (value != _radio)
                {
                    _radio = value;
                }
            }
        }

        public bool Conectado
        {
            get 
            {
                return _rectangulo != null && _circunferencia != null;
            }
        }

        public string Color
        {
            get 
            {
                if (Conectado)
                {
                    return "green";
                }
                else
                {
                    return "red";
                }
            }
        }

        public string Mensaje
        {
            get { return _mensaje; }
            set 
            {
                if (value != _mensaje)
                {
                    _mensaje = value;
                    NotificarCambioDePropiedad("Mensaje");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotificarCambioDePropiedad(string propiedad)
        {
            PropertyChangedEventHandler manejador = PropertyChanged;
            if (manejador != null)
            {
                manejador(this, new PropertyChangedEventArgs(propiedad));
            }
        }

        public void Calcular()
        {
            try
            {
                _rectangulo = new Rectangulo(double.Parse(LadoMayor), double.Parse(LadoMenor));
                _circunferencia = new Circunferencia(double.Parse(Radio));
                NotificarCambioDePropiedad("AreaRectangulo");
                NotificarCambioDePropiedad("Perimetro");
                NotificarCambioDePropiedad("AreaCircunferencia");
                NotificarCambioDePropiedad("Longitud");
                NotificarCambioDePropiedad("Conectado");
                NotificarCambioDePropiedad("Color");
                Mensaje = "Cálculo realizado con éxito";
            }
            catch (Exception e)
            {

                Mensaje = e.Message;
            }
        }

        public void Limpiar()
        {
            _rectangulo = null;
            _circunferencia = null;
            NotificarCambioDePropiedad("AreaRectangulo");
            NotificarCambioDePropiedad("Perimetro");
            NotificarCambioDePropiedad("AreaCircunferencia");
            NotificarCambioDePropiedad("Longitud");
            NotificarCambioDePropiedad("Conectado");
            NotificarCambioDePropiedad("Color");
            Mensaje = "Se ha limpiado la interfaz";
        }

        public ICommand Calcular_Click
        {
            get
            {
                return new RelayComand(o => Calcular(), o => true);
            }
        }

        public ICommand Limpiar_Click
        {
            get
            {
                return new RelayComand(o => Limpiar(), o => true);
            }
        }
    }
}
