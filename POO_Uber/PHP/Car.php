<?php

class Car
{
    public $id;
    public $license;
    public $driver;
    protected $passenger;

    public function __construct($license, $driver)
    {
        $this->license = $license;
        $this->driver = $driver;
    }

    public function DataCar()
    {
        $strCar = "License: " . $this->license;
        $strCar = $strCar . "\nDriver Name: " . $this->driver->name;
        $strCar = $strCar . "\nPassenger: " . $this->passenger;
        return $strCar;
    }

    public function getPassenger()
    {
        return $this->passenger;
    }

    public function setPassenger($passenger)
    {
        if ($passenger == 4) {
            $this->passenger = $passenger;
        } else {
            echo "Debe asignar 4 pasajeros";
        }
    }
}
