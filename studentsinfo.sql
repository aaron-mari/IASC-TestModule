-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 04, 2020 at 05:37 AM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `iacsc-testproject`
--

-- --------------------------------------------------------

--
-- Table structure for table `studentsinfo`
--

CREATE TABLE `studentsinfo` (
  `id` int(11) NOT NULL,
  `firstName` varchar(20) NOT NULL,
  `middleName` varchar(20) NOT NULL,
  `lastName` varchar(20) NOT NULL,
  `gender` varchar(6) NOT NULL,
  `birthDate` varchar(10) NOT NULL,
  `address` varchar(100) NOT NULL,
  `contactNo` varchar(12) NOT NULL,
  `email` varchar(50) NOT NULL,
  `courseid` int(11) NOT NULL,
  `yearid` int(10) NOT NULL,
  `image` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `studentsinfo`
--

INSERT INTO `studentsinfo` (`id`, `firstName`, `middleName`, `lastName`, `gender`, `birthDate`, `address`, `contactNo`, `email`, `courseid`, `yearid`, `image`) VALUES
(3, 'Torahiko', 'T.', 'Ooshima', 'Male', '2004-08-19', 'Minasato, Japan', '964-848-7753', 'ooshima_torahiko@kemono.jp', 1, 1, 'images/tora.png'),
(4, 'Kenji', 'B.', 'Mikazuki', 'Male', '2003-06-19', 'Minasato, Japan', '908-586-2174', 'kenji_mikazuki@kemono.jp', 1, 1, 'images/kenji.png'),
(5, 'Juuichi', 'B.', 'Mikazuki', 'Male', '2003-06-19', 'Minasato, Japan', '930-293-1283', 'juuichi_mikazuki@kemono.cc', 3, 2, 'images/juuichi.jpg'),
(6, 'Kyouji', 'D.', 'Takahara', 'Male', '2004-02-14', 'Minasato, Japan', '939-445-9533', 'kyouji_takahara@kemono.cc', 1, 2, 'images/kyouji.png'),
(7, 'Soutarou', 'L.', 'Touno', 'Male', '2005-09-21', 'Minasato, Japan', '934-665-2243', 'soutarou_touno@kemono.cc', 3, 1, 'images/soutarou.png'),
(8, 'Hiroyuki', 'H.', 'Nishimura', 'Male', '2004-05-23', 'Minasato, Japan', '939-485-2234', 'hiroyuki_nishimura@kemono.cc', 3, 1, 'images/hiroyuki.png');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `studentsinfo`
--
ALTER TABLE `studentsinfo`
  ADD PRIMARY KEY (`id`),
  ADD KEY `courseid` (`courseid`),
  ADD KEY `yearid` (`yearid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `studentsinfo`
--
ALTER TABLE `studentsinfo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `studentsinfo`
--
ALTER TABLE `studentsinfo`
  ADD CONSTRAINT `studentsinfo_ibfk_1` FOREIGN KEY (`courseid`) REFERENCES `course` (`id`),
  ADD CONSTRAINT `studentsinfo_ibfk_2` FOREIGN KEY (`yearid`) REFERENCES `yearlevel` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
