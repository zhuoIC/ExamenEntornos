using System;

namespace Wpf_ExamenEntornos
{
    public class Rectangulo : IFigura
    {
        double _ladoMayor;
        double _ladoMenor;

        public Rectangulo(double ladoMayor, double ladoMenor)
        {
            _ladoMayor = ladoMayor;
            _ladoMenor = ladoMenor;
        }

        public double Area
        {
            get { return _ladoMenor*_ladoMayor; }
        }

        public double Perimetro
        {
            get { return _ladoMenor*2 + _ladoMenor*2; }
        }
    }

    class Circunferencia: IFigura
    {
        double _radio;

        public Circunferencia(double radio)
        {
            _radio = radio;
        }

        public double Area
        {
            get { return Math.PI * Math.Pow(_radio, 2); }
        }

        public double Perimetro
        {
            get { return 2 * Math.PI * _radio; }
        }
    }
    
}
