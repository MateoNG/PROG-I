using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallo_404947_PROG_P._3._33_Banco
{
    internal class Cuenta
    {
        //atributos
        private Cliente[] Clientes;
        private int Ultimo;

        //datos que pide la act.
        //calcular la cantidad de cajas de ahorro y de cuentas corriente
        private int CantCajasAhorro;
        private int CantCuentasCorriente;

        
        //saldo promedio para caja de ahorro, para cuenta corriente y general
        private double SaldoPromCAhorro;
        private double SaldoPromCCorriente;
        private double PromGeneral;

        //porcentaje de clientes femeninos
        private double PorcentFemeninos;

        //el cliente con mayor límite de crédito.
        //private Cliente MayLimCredito;


        //constructores

        //Constructor
        public Cuenta()
        {
            Clientes = new Cliente[10];
            Ultimo = 0;
        }

        public Cuenta(int cantidad)
        {
            Clientes = new Cliente[cantidad];
            Ultimo = 0;
        }

        //Métodos

        
        public bool AgregarCliente(Cliente cliente)
        {
            if (Ultimo < Clientes.Length)
            {
                Clientes[Ultimo] = cliente;
                Ultimo++;
                return true;
            }
            else
                return false;
        }

        // calcular la cantidad de cajas de ahorro y de cuentas corriente
        public string CantCajasYCuentas()
        {


            for (int i = 0; i < Ultimo; i++)
            {

                if(Clientes[i].pTipoCaja == 1)
                {
                    CantCajasAhorro++;

                } else if(Clientes[i].pTipoCaja == 2)
                {
                    CantCuentasCorriente++;

                }
            }

            return "|Cajas de Ahorro: " + CantCajasAhorro +
                   "|Cuentas Corriente: " + CantCuentasCorriente;

        }

        //saldo promedio para caja de ahorro, para cuenta corriente y general
        public string Promedios() 
        {
           
            // caja de ahorro
            double SaldosT1 = 0;
            

            // cuenta corriente
            double SaldosT2 = 0;
            


            for (int i = 0; i < Ultimo; i++)
            {

                if (Clientes[i].pTipoCaja == 1)
                {
                    SaldosT1 += Clientes[i].pSaldoCuenta;

                }
                else if (Clientes[i].pTipoCaja == 2)
                {
                    SaldosT2 += Clientes[i].pSaldoCuenta; ;

                }
                SaldoPromCAhorro = SaldosT1 / CantCajasAhorro;
                SaldoPromCCorriente = SaldosT2 / CantCuentasCorriente;
                PromGeneral = SaldoPromCAhorro + SaldoPromCCorriente / 2;
            }

            return "|Promedio Cajas de Ahorro: $" + SaldoPromCAhorro +
                   "|Promedio Cuentas Corriente: $" + SaldoPromCCorriente +
                   "|Promedio General: $" + PromGeneral;
        }

           
        //nuevo
            public string ClienteMayorLimite()
            {
                int codClienteMayLim = 0;
                double mayorLim = 0;

                for (int i = 0; i < Ultimo; i++)
                {
                    if (Clientes[i].pLimCredito > mayorLim)
                    {
                        mayorLim = Clientes[i].pLimCredito;
                        codClienteMayLim = Clientes[i].pCodigo;
                    }
                }

                return "El Código del cliente con mayor límite de crédito es: " + codClienteMayLim;
            }

        //porcentaje de clientes femeninos 
        public string PorcentajeFemeninos()//(No funciona)
        {
            double feme = 0;
            double totalClientes = 0;

            for (int i = 0; i<Clientes.Length; i++)
            {
       
                if (Clientes[i].pSexo == "F")
                {
                    feme++;
                    totalClientes++;
                } else
                {
                    totalClientes++;
                }
                
                PorcentFemeninos = feme / totalClientes * 100;
            }
            
            return "Porcentaje Clientes Femeninos: %" + PorcentFemeninos;

        }


    }
}
    

