<?php


require_once("Account.php");
require_once("Driver.php");
require_once("User.php");
require_once("Car.php");
require_once("UberX.php");
require_once("UberPool.php");


$car = new Car("TDF344", new Driver("Angel Cruz", "133551","ese@oh.co","sd6c51"));
$car->setPassenger(2);

echo "<p>";
echo $car->DataCar();
echo "</p>";

$uberx = new UberX("TDY533",new Driver("Angel Paez","95874544","odi@es.co","sd65c1s"),"Kia","2020");
echo "<p>";
echo $uberx->DataCar();
echo "</p>";

$uberPool = new UberPool("KIU645",new Driver("Andrea Ruiz","6984165","doe@dd.co","6s5d1v65ds"),"Renault","2021");
echo "<p>";
echo $uberPool->DataCar();
echo "</p>";

