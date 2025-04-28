-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Apr 28, 2025 at 06:16 PM
-- Server version: 10.11.10-MariaDB-log
-- PHP Version: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `u499761150_hoteldam`
--

-- --------------------------------------------------------

--
-- Table structure for table `clientes`
--

CREATE TABLE `clientes` (
  `dniCliente` varchar(255) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `apellidos` varchar(255) NOT NULL,
  `telefono` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `direccion` varchar(255) NOT NULL,
  `cp` int(11) NOT NULL,
  `localidad` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `empleados`
--

CREATE TABLE `empleados` (
  `dniEmpleado` varchar(255) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `apellidos` varchar(255) NOT NULL,
  `telefono` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `fechaContrato` date NOT NULL,
  `turno` enum('Mañanas','Tardes','Noches') NOT NULL,
  `salarioBase` double(10,2) NOT NULL,
  `usuario` varchar(255) NOT NULL,
  `pass` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `empleados`
--

INSERT INTO `empleados` (`dniEmpleado`, `nombre`, `apellidos`, `telefono`, `email`, `fechaContrato`, `turno`, `salarioBase`, `usuario`, `pass`) VALUES
('12345678D', 'ADMIN', 'ADMIN', 666666666, 'admin@admin.com', '2025-04-13', 'Mañanas', 30000.00, 'admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `reserva_habitacion`
--

CREATE TABLE `reserva_habitacion` (
  `idReserva` int(11) NOT NULL,
  `dniCliente` varchar(255) NOT NULL,
  `fechaEntrada` date NOT NULL,
  `fechaSalida` date NOT NULL,
  `tipoHabitacion` enum('Sencilla','Doble') NOT NULL,
  `noches` int(11) NOT NULL,
  `precioTotal` double(10,2) NOT NULL,
  `dniEmpleado` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `reserva_salon`
--

CREATE TABLE `reserva_salon` (
  `idReserva` int(11) NOT NULL,
  `dniCliente` varchar(255) NOT NULL,
  `fecha` date NOT NULL,
  `numPersonas` int(11) NOT NULL,
  `caterin` enum('Almuerzo','Comida','Desayuno','Cena') NOT NULL,
  `precio` double(10,2) NOT NULL,
  `dniEmpleado` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`dniCliente`);

--
-- Indexes for table `empleados`
--
ALTER TABLE `empleados`
  ADD PRIMARY KEY (`dniEmpleado`);

--
-- Indexes for table `reserva_habitacion`
--
ALTER TABLE `reserva_habitacion`
  ADD PRIMARY KEY (`idReserva`),
  ADD KEY `dniCliente` (`dniCliente`),
  ADD KEY `dniEmpleado` (`dniEmpleado`);

--
-- Indexes for table `reserva_salon`
--
ALTER TABLE `reserva_salon`
  ADD PRIMARY KEY (`idReserva`),
  ADD KEY `dniCliente` (`dniCliente`),
  ADD KEY `dniEmpleado` (`dniEmpleado`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `reserva_habitacion`
--
ALTER TABLE `reserva_habitacion`
  MODIFY `idReserva` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `reserva_salon`
--
ALTER TABLE `reserva_salon`
  MODIFY `idReserva` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `reserva_habitacion`
--
ALTER TABLE `reserva_habitacion`
  ADD CONSTRAINT `reserva_habitacion_ibfk_1` FOREIGN KEY (`dniCliente`) REFERENCES `clientes` (`dniCliente`),
  ADD CONSTRAINT `reserva_habitacion_ibfk_2` FOREIGN KEY (`dniEmpleado`) REFERENCES `empleados` (`dniEmpleado`);

--
-- Constraints for table `reserva_salon`
--
ALTER TABLE `reserva_salon`
  ADD CONSTRAINT `reserva_salon_ibfk_1` FOREIGN KEY (`dniCliente`) REFERENCES `clientes` (`dniCliente`),
  ADD CONSTRAINT `reserva_salon_ibfk_2` FOREIGN KEY (`dniEmpleado`) REFERENCES `empleados` (`dniEmpleado`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
