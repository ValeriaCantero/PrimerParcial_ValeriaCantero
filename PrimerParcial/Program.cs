// See https://aka.ms/new-console-template for more information

using Infraestructura.Conexiones;
using Microsoft.VisualBasic;
using Servicios.ContactosService;

CiudaddService ciudaddService = new CiudaddService("Server=localhost;Port=5432;UserId=postgres;Password=03postgres;Database=PrimerParcial;");
PersonaService personaService = new PersonaService("Server = localhost; Port = 5432; UserId = postgres; Password = 03postgres; Database = PrimerParcial; ");
ClienteService clienteService = new ClienteService("Server = localhost; Port = 5432; UserId = postgres; Password = 03postgres; Database = PrimerParcial; ");
CuentasService cuentasService = new CuentasService("Server = localhost; Port = 5432; UserId = postgres; Password = 03postgres; Database = PrimerParcial; ");
MovimientosService movimientosService = new MovimientosService("Server = localhost; Port = 5432; UserId = postgres; Password = 03postgres; Database = PrimerParcial; ");

var ciudad = ciudaddService.obtenerCiudad(2);
Console.WriteLine($"idCiudad: {ciudad.idCiudad},ciudad: {ciudad.ciudad}, Departamento: {ciudad.departamento}, codigo postal: {ciudad.codigoPostal}");

ciudad.idCiudad = 001;
ciudad.departamento = "Paraguari";
ciudad.ciudad = "Quiindy";
ciudad.codigoPostal = "23-34";
ciudaddService.modificarCiudad(ciudad);
//ciudaddService.EliminarCiudad(1);

var persona = personaService.obtenerPersona(2);
Console.WriteLine($"idPersona: {persona.idPersona}, nombre: {persona.nombre}, apellido: {persona.apellido}, tipo documento: {persona.tipoDocumento}," +
    $"nroDocumento: {persona.nroDocumento}, direccion: {persona.direccion}, celular: {persona.celular}, email: {persona.email}, estado: {persona.estado}");

persona.idPersona = 002;
persona.nombre = "Lujan";
persona.apellido = "Gonzalez";
persona.tipoDocumento = "cedula";
persona.nroDocumento = "6578900";
persona.direccion = "Barrio San Jose";
persona.celular = "0991897678";
persona.email = "lujangonza@gmail.com";
persona.estado = "a";
personaService.modificarPersona(persona);
//personaService.EliminarPersona(2);

var cliente = clienteService.obtenerCliente(2);
Console.WriteLine($"idCliente: {cliente.idCliente}, fechaIngreso: {cliente.fechaIngreso}, calificacion: {cliente.calificacion}, estado: {cliente.estado} ");

cliente.idCliente = 1;
cliente.fechaIngreso = DateTime.Now;
cliente.calificacion = "10";
cliente.estado = "a";
clienteService.modificarCliente(cliente);
//clienteService.EliminarCliente(1);

var cuentas = cuentasService.obtenerCuentas(2);
Console.WriteLine($"idCuenta:{cuentas.idCuenta}, nroCuenta:{cuentas.nroCuenta}, fechaAlta: {cuentas.fechaAlta}, tipoCuenta: {cuentas.tipoCuenta}," +
    $"saldo:{cuentas.saldo}, nroContacto: {cuentas.nroContacto},costoMantenimiento:{cuentas.costoMantenimiento}, " +
    $"promedioAcreditacion:{cuentas.promedioAcreditacion}, moneda: {cuentas.moneda}, estado: {cuentas.estado}");

cuentas.idCuenta = 1;
cuentas.nroCuenta = "2900";
cuentas.fechaAlta = DateTime.Now;
cuentas.tipoCuenta = "credito";
cuentas.saldo = 39000;
cuentas.nroContacto = "0981232445";
cuentas.costoMantenimiento = 89000;
cuentas.promedioAcreditacion = "88,5";
cuentas.moneda = "Gs";
cuentas.estado = "a";
cuentasService.modificarCuentas(cuentas);
//cuentasService.EliminarCuentas(1);

var movimientos = movimientosService.obtenerMovimientos(1);
Console.WriteLine($"idMovimiento: {movimientos.idMovimiento}, fechaMovimiento: {movimientos.fechaMovimiento},tipoMovimiento:{movimientos.tipoMovimiento}," +
    $"sueldoAnterior: {movimientos.sueldoAnterior}, sueldoAnual: {movimientos.sueldoAnual}, montoMovimiento: {movimientos.montoMovimiento}," +
    $"cuentaOrigen: {movimientos.cuentaOrigen}, cuentaDestino: {movimientos.cuentaDestino}, canal: {movimientos.canal} ");

movimientos.idMovimiento = 1;
movimientos.fechaMovimiento = DateTime.Now;
movimientos.tipoMovimiento = "010";
movimientos.sueldoAnterior = 2000000;
movimientos.sueldoAnual = 3000000;
movimientos.montoMovimiento = 1000000;
movimientos.cuentaDestino = 100;
movimientos.cuentaOrigen = 102;
movimientos.canal = 03;
movimientosService.modificarMovimientos(movimientos);
//movimientosService.EliminarMovimientos(1);

