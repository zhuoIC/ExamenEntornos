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
        double _ladoMayor = 15;
        double _ladoMenor = 12;
        double _radio = 5;
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

        public double LadoMayor
        {
            get { return _ladoMayor; }
            set 
            {
                if (value != _ladoMayor && value >= 0)
                {
                    try
                    {
                        _ladoMayor = value;
                    }
                    catch (Exception e)
                    {
                        Mensaje = e.Message;
                    }
                }
            }
        }

        public double LadoMenor
        {
            get { return _ladoMenor; }
            set
            {
                if (value != _ladoMenor && value >= 0)
                {
                    try
                    {
                        _ladoMenor = value;
                    }
                    catch (Exception e)
                    {
                        Mensaje = e.Message;
                    }
                }
            }
        }

        public double Radio
        {
            get { return _radio; }
            set
            {
                if (value != _radio && value >= 0)
                {
                    try
                    {
                        _radio = value;
                    }
                    catch (Exception e)
                    {
                        Mensaje = e.Message;
                    }
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
                    NotificarCambioDePropiedad(_mensaje);
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
            _rectangulo = new Rectangulo(LadoMayor, LadoMenor);
            _circunferencia = new Circunferencia(Radio);
            NotificarCambioDePropiedad("AreaRectangulo");
            NotificarCambioDePropiedad("Perimetro");
            NotificarCambioDePropiedad("AreaCircunferencia");
            NotificarCambioDePropiedad("Longitud");
            NotificarCambioDePropiedad("Conectado");
            NotificarCambioDePropiedad("Color");
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
