using Gallo_404947_PROG_P._3._33_Banco;

//creacion clientes
Cliente c1, c2, c3;

c1 = new Cliente(45934846, 001, 90000, 1, 5000, "Mateo Gallo", 18, "M", 65, 1.72);

c2 = new Cliente(28567122, 002, 150000, 1, 20000, "Matias Zarembo", 42, "M", 70, 1.70);

c3 = new Cliente(34446721, 003, 2000000, 2, 1000000, "Yanina Argañaraz", 36, "F", 60, 1.60);

//creacion cuenta
Cuenta cuenta1;

cuenta1 = new Cuenta(3);

//se agregan los clientes
cuenta1.AgregarCliente(c1);
cuenta1.AgregarCliente(c2);
cuenta1.AgregarCliente(c3);

//procesos
Console.WriteLine(cuenta1.CantCajasYCuentas());

Console.WriteLine(cuenta1.Promedios());

Console.WriteLine(cuenta1.ClienteMayorLimite());

Console.WriteLine(cuenta1.PorcentajeFemeninos());
