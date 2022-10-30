package Java;

public class UberX extends Car {
    String brand;
    String model;

    public UberX(String license, Driver driver, String brand, String model) {
        super(license, driver);
        this.brand = brand;
        this.model = model;
    }

    @Override
    public String DataCar() {
        super.DataCar();
        String strCar = "Brand: " + brand;
        strCar += "\nModel: " + model;
        return strCar;
    }
}
