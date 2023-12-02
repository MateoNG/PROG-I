namespace Gallo_404947_PROG_P._3._33_Banco
{
    internal abstract class Persona
    {
        //Atributos
        protected string nombre;
        protected int edad;
        private string sexo;
        private double peso;
        private double altura;


        //Constructores
        public Persona()
        {
            nombre = String.Empty; //="";
            peso = altura = edad = 0;
            sexo = String.Empty;
        }


        //el que voy a usar
        public Persona(string nombre, int edad, string sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
            this.altura = 0;
            this.peso = 0;
        }

        public Persona(string nombre, int edad, string sexo, double peso, double altura)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
            this.peso = peso;
            this.altura = altura;
        }


        //Propiedades
        public string pNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int pEdad
        {
            get { return edad; }
            set { edad = value; }
        }
        public string pSexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public double pPeso
        {
            get { return peso; }
            set { peso = value; }
        }
        public double pAltura
        {
            get { return altura; }
            set { altura = value; }
        }

        //Metodos()
        public override string ToString() //Redefine el metodo ToString() de la clase Object
        {
            string s = "";
            if (sexo == "M")
                s = "Mujer";
            else
                s = "Hombre";

            string aux = "";

            aux = " | Nombre: " + nombre
                 + " | Edad: " + edad
                 + " | Sexo: " + s
                 + " | Peso: " + peso
                 + " | Altura: " + altura
                 + " | IMC: " + calcularIMC();

            return aux;
        }
        public int calcularIMC()
        {
            int aux = 0;
            double imc = 0;
            imc = peso / (altura * altura);
            if (imc < 20)
                aux = -1;
            else
                if (imc > 25)
                aux = 1;
            else
                aux = 0;
            return aux;
        }
        virtual public bool esMayorDeEdad() //Metodo virtual que se redefine en la clase hija
        {
            /*
            bool aux=false;
            if (edad > 21) aux = true;
            return aux;
            */
            if (edad > 21)
                return true;
            else
                return false;
        }

        

        //abstract public void cumpleanio();  //Metodo abstracto que se redefine en la clase hija
    }
}