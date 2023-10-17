-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 07, 2021 at 08:03 AM
-- Server version: 10.3.16-MariaDB
-- PHP Version: 7.3.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `librarysystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `bookrecord`
--

CREATE TABLE `bookrecord` (
  `Book Id` varchar(10) NOT NULL,
  `Book Name` varchar(250) DEFAULT NULL,
  `Book Author` varchar(250) DEFAULT NULL,
  `Book Publication` varchar(250) DEFAULT NULL,
  `Book Edition` varchar(100) DEFAULT NULL,
  `Availability` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bookrecord`
--

INSERT INTO `bookrecord` (`Book Id`, `Book Name`, `Book Author`, `Book Publication`, `Book Edition`, `Availability`) VALUES
('B001', 'dkjfh', 'adfaf', 'adfaf', '3243', 0),
('B002', 'dkjfh', 'adfaf', 'adfaf', '3243', 0),
('B003', 'dfa', 'dafafdfa', 'adfaf', '3', 0),
('B004', 'dfa', 'dafafdfa', 'adfaf', '3', 1),
('B005', 'dfa', 'dafafdfa', 'adfaf', '3', 0),
('B006', 'dfa', 'dafafdfa', 'adfaf', '3', 0),
('B007', 'dfa', 'dafafdfa', 'adfaf', '3', 1);

-- --------------------------------------------------------

--
-- Table structure for table `logintable`
--

CREATE TABLE `logintable` (
  `user_id` varchar(10) NOT NULL,
  `user_password` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `logintable`
--

INSERT INTO `logintable` (`user_id`, `user_password`) VALUES
('S001', '12345'),
('S002', '123456');

-- --------------------------------------------------------

--
-- Table structure for table `providebook`
--

CREATE TABLE `providebook` (
  `Book Id` varchar(10) NOT NULL,
  `Student Id` varchar(10) NOT NULL,
  `Date To` date NOT NULL,
  `Date From` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `providebook`
--

INSERT INTO `providebook` (`Book Id`, `Student Id`, `Date To`, `Date From`) VALUES
('B001', 'S002', '2021-04-07', '2021-04-07'),
('B002', 'S001', '2021-04-07', '2021-04-07'),
('B003', 'S003', '2021-04-06', '2021-04-07'),
('B005', 'S001', '2021-04-07', '2021-04-07'),
('B006', 's001', '2021-04-08', '2021-04-08'),
('b007', 's003', '2021-04-07', '2021-04-10');

-- --------------------------------------------------------

--
-- Table structure for table `studentrecord`
--

CREATE TABLE `studentrecord` (
  `Student Id` varchar(10) NOT NULL,
  `Student Name` varchar(250) DEFAULT NULL,
  `Father Name` varchar(250) DEFAULT NULL,
  `Address` text DEFAULT NULL,
  `Mobile Number` varchar(20) DEFAULT NULL,
  `Phone Number` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `studentrecord`
--

INSERT INTO `studentrecord` (`Student Id`, `Student Name`, `Father Name`, `Address`, `Mobile Number`, `Phone Number`) VALUES
('S001', 'Aman kumar', 'Kailash kumar sah', 'Katihar', '9128161663', '6202440500'),
('S002', 'Jayram Kumar', 'xyz', 'banka', '123456790', ''),
('S003', 'adfa', 'afgag', 'dafgg', '4254252524', '2454668875'),
('S004', 'dfa', 'daf', 'adf', '43234', '342'),
('S005', 'ewd', 'dfa', 'dsafaf', '24324', '4535'),
('S006', 'erfdsaf', 'afa', 'dafafdf324658768', '753852742', '952741852'),
('S007', 'fddag', 'adfa', 'asfadfa', '34465', '532525'),
('S008', 'dfgs', 'gdrgft', 'retwt', '43578856', '455656');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bookrecord`
--
ALTER TABLE `bookrecord`
  ADD PRIMARY KEY (`Book Id`);

--
-- Indexes for table `logintable`
--
ALTER TABLE `logintable`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `providebook`
--
ALTER TABLE `providebook`
  ADD UNIQUE KEY `Book Id` (`Book Id`);

--
-- Indexes for table `studentrecord`
--
ALTER TABLE `studentrecord`
  ADD PRIMARY KEY (`Student Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
