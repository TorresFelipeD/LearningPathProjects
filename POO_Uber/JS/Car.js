class Car {
    constructor(license, driver) {
        this.id;
        this.license = license;
        this.driver = driver;
        this.passenger;
    }

    DataCar(){
        console.log("License: " + this.license);
        console.log(this.driver);
        console.log("Driver Name: " + this.driver.name);
        console.log("Driver Document: " + this.driver.document);
        console.log("Passenger: " + this.passenger);
    }
}