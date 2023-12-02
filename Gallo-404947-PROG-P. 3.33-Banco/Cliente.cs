using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallo_404947_PROG_P._3._33_Banco
{
    internal class Cliente :Persona
    {
        //dni, codigo, limite de credito, tipo (1 caja ahorro o 2 caja corriente), saldo de cuenta

        //atributos

        private Int64 DNI;
        private int Codigo;
        private double LimCredito;
        private int TipoCaja;
        private double SaldoCuenta;

        //propiedades
        public Int64 pDNI
        {
            get{ return DNI; }
            set { DNI = value; }
        }

        public int pCodigo
        {
            get {return Codigo; }
            set {Codigo = value; }
        }

        public double pLimCredito
        {
            get {return LimCredito; }
            set { LimCredito = value; }
        }

        public int pTipoCaja
        {
            get {return TipoCaja; }
            set { TipoCaja = value; }
        }

        public double pSaldoCuenta
        {
            get {return SaldoCuenta; }
            set { SaldoCuenta = value; }
        }

        //constructor
        public Cliente() :base()
        {
            DNI = 0;
            Codigo = 0;
            LimCredito = 0;
            TipoCaja = 0;
            SaldoCuenta = 0;

        }

        public Cliente(int dni, int codigo, double limCredito, int tipoCaja, double saldoCuenta,
                       string nombre, int edad, string sexo, double peso, double altura)
                : base(nombre, edad, sexo, peso, altura)
        {
            DNI = dni;
            Codigo = codigo;
            LimCredito = limCredito;
            TipoCaja = tipoCaja;
            SaldoCuenta = saldoCuenta;
        }

        public override string ToString()
        {
            return base.ToString() 
                 + " | DNI: " + DNI
                 + " | Codigo: " + Codigo
                 + " | LimCredito: $" + LimCredito
                 + " | TipoCaja: " + TipoCaja
                 + " | SaldoCuenta: $" + SaldoCuenta;
        }

        //nuevo
        public bool EsFemenino()
        {
            bool resp = false;

            if (base.pSexo == "F")
            {
                resp = true;
            }
            return resp;
        }
    }
}
