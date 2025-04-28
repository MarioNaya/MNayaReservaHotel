# MNayaReservaHotel 🏨

Aplicación de gestión de reservas de hotel desarrollada en **C#** con **Windows Forms** y conexión a **MySQL**.

---

## 📋 Características principales

- Registro de clientes con datos personales.
- Consulta de clientes por DNI.
- Alta de empleados.
- Sistema LOGIN para empleados.
- Reserva de habitaciones y salones.
- Conexión a base de datos **MySQL** mediante `MySqlConnector`.
- Separación del acceso a base de datos en clases específicas (`ConsultasCliente`,`ConsultasEmpleado`,`ConsultasSalon`,`ConsultasHabitacion`).
- Configuración segura de la cadena de conexión mediante `appsettings.json`.

---

## 🛢️ Base de datos

El script de la base de datos se encuentra en `/database/init.sql`.

Para importar la base de datos:

1. Abrir phpMyAdmin o tu herramienta de MySQL.
2. Crear una nueva base de datos (por ejemplo, `reservas_hotel`).
3. Importar el archivo `init.sql` en la base de datos creada.

---

## ⚙️ Requisitos

- Visual Studio 2022 o superior
- .NET Framework o .NET 6/7 (dependiendo de la configuración de tu proyecto)
- Base de datos MySQL (puedes usar [XAMPP](https://www.apachefriends.org/es/index.html) o similar localmente)

---

## 🛠 Instalación

1. **Clona el repositorio:**

   ```bash
   git clone https://github.com/MarioNaya/MNayaReservaHotel.git

## 📂 Estructura del proyecto

├── Config/               # Configuración general
│   └── Configuracion.cs
│   └── App.config
│   └── appsettings.json (solo para local)
│   └── appsettings.example.json (plantilla pública)
│
├── DataAccess/           # Acceso a base de datos (Consultas a BBDD)
│   └── ConsultasCliente.cs
│   └── ConsultasEmpleado.cs
│   └── ConsultasHabitacion.cs
│   └── ConsultasSalon.cs
│
├── Database/             # Scripts de base de datos
│   └── init.sql
│
├── Models/               # Modelos de datos (DTOs o entidades)
│   └── Cliente.cs
│   └── Empleado.cs
│   └── Habitacion.cs
│   └── Salon.cs
│
├── Resources/            # Recursos gráficos (imágenes, iconos, etc.)
│   └── hotel.jpg
│   └── hotel1.jpg
│   └── hotel11.jpg
│   └── logo.png
│
├── Utils/                # Utilidades generales
│   └── Utilidades.cs
│   └── Validacion.cs
│
├── Views/                # Formularios y pantallas
│   ├── Common/           # Formularios que se repiten
│   │   └── Login.cs
│   │   └── Principal.cs
│   ├── Clientes/
│   │   └── ReservaSalones.cs
│   │   └── ReservaHabitaciones.cs
│   ├── Empleados/
│   │   └── AltaEmpleado.cs
│   │   └── VerEmpleados.cs
│   ├── Salones/
│   │   └── VerReservasSalones.cs
│   │   └── VerReservasSalones.Designer.cs
│   │   └── VerReservasSalones.resx
│   └── Habitaciones/
│       └── VerReservasHabitaciones.cs
│
├── MNayaReservaHotel.csproj
├── Program.cs
└── README.md

