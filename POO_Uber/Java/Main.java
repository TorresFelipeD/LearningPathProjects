package Java;

class Main {
    public static void main(String[] args) {
        System.out.println("Hola Mundo");

        // Car car = new Car("ABC123", new Account("Diego Torres", "81512323"));
        Car car = new Car("ABC123",new Driver("Diego Torres", "85741522", "es@es.co", "es85de"));
        car.setPassenger(2);
        System.out.println("Car license: " + car.license);

        Car car2 = new Car("DEA123",new Driver("Andrea Herrera", "58741555", "ese@es.co", "es85de"));
        car2.setPassenger(4);
        System.out.println("Car license: " + car2.license);

        System.out.println(car2.DataCar());

        UberVan uberVan = new UberVan("DEA123",new Driver("Andrea Herrera", "58741555", "ese@es.co", "es85de"));
        uberVan.setPassenger(6);
        System.out.println("Car license: " + uberVan.license);

        System.out.println(uberVan.DataCar());

        UberX uberX = new UberX("DEA123",new Driver("Andrea Herrera", "58741555", "ese@es.co", "es85de"),"Kia","2023");
        uberX.setPassenger(4);
        System.out.println("Car license: " + uberVan.license);

        System.out.println(uberX.DataCar());
    }
}