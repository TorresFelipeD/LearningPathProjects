package Java;

public class Car {
    Integer id;
    String license;
    Driver driver;
    protected Integer passenger;

    public Car(String license, Driver driver) {
        this.license = license;
        this.driver = driver;
    }

    public String DataCar() {
        String strCar = "id: " + id;
        strCar += "\nLicense: " + license;
        strCar += "\nDriver: " + driver.name;
        strCar += "\nPassenger: " + getPassenger();
        return strCar;
    }

    public Integer getPassenger() {
        return passenger;
    }

    public void setPassenger(Integer passenger) {
        if (passenger == 4) {
            this.passenger = passenger;

        } else {
            System.out.println("Solo se aceptan 4 pasajeros.");
        }
    }
}
